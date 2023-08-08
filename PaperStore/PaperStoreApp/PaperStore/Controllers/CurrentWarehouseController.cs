using Autofac;
using Microsoft.AspNetCore.Mvc;
using PaperStore.Services;
using PaperStore.Services.CurrentWarehouse.Create;
using PaperStore.Services.CurrentWarehouse.Delete;
using PaperStore.Services.CurrentWarehouse.Details;
using PaperStore.Services.CurrentWarehouse.Read;
using PaperStore.Services.CurrentWarehouse.Update.Single;
using PaperStore.Services.Options;
using PaperStore.WareHouseData;

namespace PaperStore.Controllers
{
    public class CurrentWarehouseController : Controller
    {
        readonly RegisterTypesContainer conn;
        readonly IContainer container;

        public CurrentWarehouseController(RegisterTypesContainer conn)
        {
            this.conn = new();
            this.container = 
                conn.ResolveContainer(new());
        }
        
        public async Task<IActionResult> Index(string ActionMessage, string productName)
        {
            ViewBag.ActionMessage = ActionMessage;
            container.Resolve<ILogging>().WriteLog(AllData.IndexPage);
            return View(await container.Resolve<IGetItem>().Item(productName));
        }
        public async Task<IActionResult> ChooseCompany()
        {
            ViewBag.ProductList = 
                await container.Resolve<IChooseCompany>().Company();
            container.Resolve<ILogging>().WriteLog(AllData.CompanyChoosingPage);
            return View();
        }
        public async Task<IActionResult> ChooseDetails(CompaniesList model)
        {
            ViewBag.ProductList = 
                await container.Resolve<IChooseDetails>().ChooseStockItem(model);

            ViewBag.AdditionalInfo = 
                await container.Resolve<IChooseDetails>().ChooseAdditionalInfo();
            container.Resolve<ILogging>().WriteLog(AllData.DetailsChoosingPage);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateItem(CurrentStock model)
        {
            container.Resolve<ILogging>().WriteLog(AllData.CreatePage);
            return RedirectToAction("Index", new { ActionMessage = await container.Resolve<ICreateItem>().Item(model) });
        }
        public async Task<IActionResult> UpdateItem(long Id, string ErrorMsg)
        {
            ViewBag.AdditionalInfo =
                await container.Resolve<IChooseDetails>().ChooseAdditionalInfo();

            ViewBag.ErrorMsg = ErrorMsg;
            container.Resolve<ILogging>().WriteLog(AllData.ItemsUpdatechoosingPage);
            return View(await container.Resolve<IGetUpdatedItem>().Item(Id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateItem(CurrentStock model)
        {
            container.Resolve<ILogging>().WriteLog(AllData.UpdatePage);
            return RedirectToAction("Index", new { ActionMessage = await container.Resolve<IUpdateItem>().Item(model) });
        }
        public async Task<IActionResult> ItemsDetails(long Id)
        {
            ViewBag.NoCompanyAttach = 
                AllData.CompanyIsNotValidMessage;
            container.Resolve<ILogging>().WriteLog(AllData.DetailsPage);
            return View(await container.Resolve<IGetDetails>().Item(Id));
        }
        public async Task<IActionResult> DeleteItem(long Id)
        {
            container.Resolve<ILogging>().WriteLog("Deleting one item");
            return RedirectToAction("Index", new { ActionMessage = await container.Resolve<IRemoveItem>().Item(Id) });
        }
        public IActionResult Contact()
        {
            container.Resolve<ILogging>().WriteLog("Seeing store info");
            return View();
        }
    }
}