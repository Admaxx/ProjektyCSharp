using Autofac;
using Microsoft.AspNetCore.Mvc;
using PaperStore.Services.ActualInventory.Create;
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
    }
}
