using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaperStoreApplication.Services.ActualInventory.Delete;
using PaperStoreApplication.Services.ActualInventory.Update;
using PaperStoreApplication.Services.LastItem.Create;
using PaperStoreApplication.Services.LastItem.Read;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStore.Controllers;

[Route("api/[controller]")]//A little refactorization needed in this controller
public class LastItemController(Container conn, ILoggerFactory logger, IMapper profilMapper) : Controller //This controller serving only non-archive items
{
    IContainer _lastItemContainer { get; init; } = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
    ILogger<LastItemController> _logger { get; init; } = logger.CreateLogger<LastItemController>();
    IMapper mapProfile { get; init; } = profilMapper;

    [HttpGet]
    public IActionResult GetActualItems()
    {
        _logger.LogInformation(AllData.ReadActionMessage);

        return Ok(_lastItemContainer.Resolve<IGetLast>().LastItem());
    }
    [HttpPost]
    public IActionResult CreateItem(ModifyItemModel model) //If updating qty, it adding exists qty to new one
    {
        _logger.LogInformation(AllData.CreateActionMessage);

        return _lastItemContainer.Resolve<ICreateItem>().CreateItemByName(model).Result ?
        CreatedAtAction(nameof(CreateItem), AllData.CreateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpPut]
    public IActionResult UpdateItem(long Id, ModifyItemModel model) //If updating qty, it reseting qty, and replacing it by new one
    {
        _logger.LogInformation(AllData.UpdateActionMessage);

        return _lastItemContainer.Resolve<IUpdateItem>().UpdateItemByName(Id, model, true).Result ?
        Ok(AllData.UpdateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpDelete]
    public IActionResult DeleteItem(long Id)
    {
        _logger.LogInformation(AllData.DeleteActionMessage);

        return _lastItemContainer.Resolve<IDeleteItem>().ItemById(Id, false).Result ?
        Ok(AllData.DeleteSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
}