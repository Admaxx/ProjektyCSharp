using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PaperStoreApplication.Services.ActualInventory.Delete;
using PaperStoreApplication.Services.ActualInventory.Options;
using PaperStoreApplication.Services.ActualInventory.Update;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStore.Controllers;

[Route("api/[controller]")]
public class ActualInventoryController(Container conn, ILogger<ActualInventoryController> logger, IMapper profilMapper) : Controller //This controller serving only non-archive items
{
    IContainer ActualContainer { get; init; } = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
    ILogger<ActualInventoryController> Logger { get; init; } = logger;
    IMapper MapProfile { get; init; } = profilMapper;

    [HttpGet]
    [OutputCache(PolicyName = "ItemsCachePolicy")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetActualItems()
    {
        Logger.LogInformation(AllData.ReadActionMessage);

        return Ok(ActualContainer.Resolve<IReadAllItems>().GetAllItems(IsArchive: false)
           .Select(MapProfile.Map<ModifyItemModel>) //First attemts to use AutoMapper, not proud of place and code quality, will fix soon
            );
    }
    [HttpPost]
    public IActionResult CreateItem(ModifyItemModel model) //If updating qty, it adding exists qty to new one
    {
        Logger.LogInformation(AllData.CreateActionMessage);

        return ActualContainer.Resolve<ICreateOrUpdate>().ChooseItem(model) ?
        CreatedAtAction(nameof(CreateItem), AllData.CreateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpPut]
    public IActionResult UpdateItem(long Id, ModifyItemModel model) //If updating qty, it reseting qty, and replacing it by new one
    {
        Logger.LogInformation(AllData.UpdateActionMessage);

        return ActualContainer.Resolve<IUpdateItem>().UpdateItemByName(Id, model, true).Result ?
        Ok(AllData.UpdateSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
    [HttpDelete]
    public IActionResult DeleteItem(long Id)
    {
        Logger.LogInformation(AllData.DeleteActionMessage);

        return ActualContainer.Resolve<IDeleteItem>().ItemById(Id, false).Result ?
        Ok(AllData.DeleteSuccessMessage) : BadRequest(AllData.BadRequestMessage);
    }
}