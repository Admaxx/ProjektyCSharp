using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaperStoreApplication.Services.LastItem.Delete;
using PaperStoreApplication.Services.LastItem.Update;
using PaperStoreApplication.Services.LastItem.Create;
using PaperStoreApplication.Services.LastItem.Read;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;
using Microsoft.AspNetCore.OutputCaching;

namespace PaperStore.Controllers;

[Route("api/[controller]")]//A little refactorization in this controller needed
public class LastItemController(Container conn, ILoggerFactory logger, IMapper profilMapper) : Controller //This controller serving only non-archive items
{
    IContainer _lastItemContainer { get; init; } = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
    ILogger<LastItemController> _logger { get; init; } = logger.CreateLogger<LastItemController>();
    IMapper mapProfile { get; init; } = profilMapper;

    [HttpGet]
    [OutputCache(PolicyName = "ItemsCachePolicy")]
    public IActionResult GetLastElement()
    {
        _logger.LogInformation(AllData.ReadActionMessage);

        return Ok(profilMapper.Map<CurrentStock, ModifyItemModel>(_lastItemContainer.Resolve<IGetLast>().LastItem()));
    }
    [HttpPost]
    public IActionResult AddToLastItem(ModifyItemModel model) //If updating qty, it adding exists qty to new one
    {
        _logger.LogInformation(AllData.CreateActionMessage);

        return _lastItemContainer.Resolve<ICreateItem>().AddQtyUpdateRemainingItems(model, false).Result ?
        CreatedAtAction(nameof(AddToLastItem), AllData.CreateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpPut]
    public IActionResult UpdateToLastItem(ModifyItemModel model) //If updating qty, it reseting qty, and replacing it by new one
    {
        _logger.LogInformation(AllData.UpdateActionMessage);

        return _lastItemContainer.Resolve<IUpdateItem>().UpdateQtyAndRemainingItems(model, true).Result ?
        Ok(AllData.UpdateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpDelete]
    public IActionResult DeleteLastItem()
    {
        _logger.LogInformation(AllData.DeleteActionMessage);

        return _lastItemContainer.Resolve<IDeleteItem>().RemoveLastElement(false).Result ?
        Ok(AllData.DeleteSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
}