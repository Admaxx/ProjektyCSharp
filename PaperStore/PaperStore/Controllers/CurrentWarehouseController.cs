using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperStore.Services;
using PaperStore.Services.Create;
using PaperStore.Services.Delete;
using PaperStore.Services.Details;
using PaperStore.Services.Options;
using PaperStore.Services.Read;
using PaperStore.Services.Update;
using PaperStore.WareHouseData;

namespace PaperStore.Controllers
{
    public class CurrentWarehouseController : Controller
    {
        RegisterTypesContainer conn;
        IContainer container;
        public CurrentWarehouseController(RegisterTypesContainer conn)
        {
            this.conn = new RegisterTypesContainer();
            this.container = 
                conn.ResolveContainer(new ContainerBuilder());
        }
        
        public async Task<IActionResult> Index(string ActionMessage)
        {
            ViewBag.ActionMessage = ActionMessage;

            return View(await container.Resolve<IGetItem>().Item());
        }
        public async Task<IActionResult> ChooseCompany()
        {
            ViewBag.ProductList = 
                await container.Resolve<IChooseCompany>().Company();

            return View();
        }
        public async Task<IActionResult> ChooseDetails(CompaniesList model)
        {
            ViewBag.ProductList = 
                await container.Resolve<IChooseDetails>().ChooseStockItem(model);

            ViewBag.AdditionalInfo = 
                await container.Resolve<IChooseDetails>().ChooseAdditionalInfo();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateItem(CurrentStock model)
            => 
            RedirectToAction("Index", new { ActionMessage = await container.Resolve<ICreateItem>().Item(model) }) ;
        
        public async Task<IActionResult> UpdateItem(long Id, string ErrorMsg)
        {
            ViewBag.AdditionalInfo =
                await container.Resolve<IChooseDetails>().ChooseAdditionalInfo();

            ViewBag.ErrorMsg = ErrorMsg;

            return View(await container.Resolve<IGetUpdatedItem>().Item(Id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateItem(CurrentStock model)
            => 
            RedirectToAction("Index", new { ActionMessage = await container.Resolve<IUpdateItem>().Item(model) });
        
        public async Task<IActionResult> ItemsDetails(long Id)
        {
            ViewBag.NoCompanyAttach = 
                AllData.CompanyIsNotValidMessage;

            return View(await container.Resolve<IGetDetails>().Item(Id));
        }
        public async Task<IActionResult> DeleteItem(long Id)
            => 
            RedirectToAction("Index", new { ActionMessage = await container.Resolve<IRemoveItem>().Item(Id) });
        
        public IActionResult Contact()
            =>
            View();
    }
}