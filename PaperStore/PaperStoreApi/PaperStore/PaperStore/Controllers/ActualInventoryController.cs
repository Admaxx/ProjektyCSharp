using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaperStoreApplication.Services.ActualInventory.Create;
using PaperStoreApplication.Services.ActualInventory.Delete;
using PaperStoreApplication.Services.ActualInventory.Update;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStore.Controllers;

[Route("api/[controller]")]
public class ActualInventoryController(Container conn, ILogger<ActualInventoryController> logger, IMapper profilMapper) : Controller
{
    IContainer _actualContainer { get; init; } = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
    ILogger<ActualInventoryController> _logger { get; init; } = logger;
    IMapper mapProfile { get; init; } = profilMapper;

    [HttpGet]
    public IActionResult GetActualItems()
    {
        _logger.LogInformation("Attempting to get all items");


        return Ok(_actualContainer.Resolve<IReadAllItems>().GetAllItems(IsArchive: false).Result
            .Select(mapProfile.Map<ModifyItemModel>) //First attemts to use AutoMapper, not proud of place and code quality, will fix soon
            );
    }
    [HttpPost]
    public IActionResult CreateItem(ModifyItemModel model)
    {
        _logger.LogInformation("Attempting to create new item");

        return _actualContainer.Resolve<ICreateItem>().CreateItemByName(model).Result ?
        CreatedAtAction(nameof(CreateItem), AllData.CreateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpPut]
    public IActionResult UpdateItem(long Id, int? Qty, string AdditionalInfo)
    {
        _logger.LogInformation("Attempting to update item");

        return _actualContainer.Resolve<IUpdateItem>().UpdateItemByName(Id, Qty, AdditionalInfo).Result ?
        StatusCode(200, AllData.UpdateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpDelete]
    public IActionResult DeleteItem(long Id)
    {
        _logger.LogInformation("Attempting to delete item");

        return _actualContainer.Resolve<IDeleteItem>().ItemById(Id, false).Result ?
        StatusCode(200, AllData.DeleteSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
}