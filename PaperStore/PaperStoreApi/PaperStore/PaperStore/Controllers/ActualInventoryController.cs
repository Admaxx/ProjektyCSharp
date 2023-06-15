using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaperStoreApplication.Services.ActualInventory.Delete;
using PaperStoreApplication.Services.ActualInventory.Options;
using PaperStoreApplication.Services.ActualInventory.Update;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStore.Controllers;

[Route("api/[controller]")]
public class ActualInventoryController(Container conn, ILoggerFactory logger, IMapper profilMapper) : Controller
{
    IContainer _actualContainer { get; init; } = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
    ILogger<ActualInventoryController> _logger { get; init; } = logger.CreateLogger<ActualInventoryController>();
    IMapper mapProfile { get; init; } = profilMapper;

    [HttpGet]
    public IActionResult GetActualItems()
    {
        _logger.LogInformation(AllData.ReadActionMessage);

        return Ok(_actualContainer.Resolve<IReadAllItems>().GetAllItems(IsArchive: false).Result
           .Select(mapProfile.Map<ModifyItemModel>) //First attemts to use AutoMapper, not proud of place and code quality, will fix soon
            );
    }
    [HttpPost]
    public IActionResult CreateItem(ModifyItemModel model)
    {
        _logger.LogInformation(AllData.CreateActionMessage);

        return _actualContainer.Resolve<ICreateOrUpdate>().ChooseItem(model) ?
        CreatedAtAction(nameof(CreateItem), AllData.CreateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpPut]
    public IActionResult UpdateItem(long Id, ModifyItemModel model)
    {
        _logger.LogInformation(AllData.UpdateActionMessage);

        return _actualContainer.Resolve<IUpdateItem>().UpdateItemByName(Id, model, true).Result ?
        StatusCode(200, AllData.UpdateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpDelete]
    public IActionResult DeleteItem(long Id)
    {
        _logger.LogInformation(AllData.DeleteActionMessage);

        return _actualContainer.Resolve<IDeleteItem>().ItemById(Id, false).Result ?
        StatusCode(200, AllData.DeleteSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
}