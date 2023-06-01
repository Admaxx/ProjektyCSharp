﻿using Autofac;
using Microsoft.AspNetCore.Mvc;
using PaperStore.Services.ActualInventory.Create;
using PaperStore.Services.ActualInventory.Delete;
using PaperStore.Services.ActualInventory.Update;
using PaperStore.Services.OptionsForServices;
namespace PaperStore.Controllers
{
    [Route("api/[controller]")]
    public class ActualInventoryController : Controller
    {
        readonly IContainer _actualContainer;
        readonly ILogger<ActualInventoryController> _logger;
        public ActualInventoryController(Container conn, ILogger<ActualInventoryController> logger)
        {
            this._actualContainer = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult GetActualItems()
        {
            _logger.LogInformation("Getting current items");

            return Ok(_actualContainer.Resolve<IReadAllItems>().GetAllItems(IsArchive: false));
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
}