using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using PaperStore.WareHouseData;

namespace PaperStore.Controllers
{
    public class CurrentWarehouseController : Controller
    {
        PaperWarehouseContext context;

        public CurrentWarehouseController(PaperWarehouseContext _context)
            =>
            this.context = _context;
        
        public async Task<IActionResult> Index(string ActionMessage)
        {
            ViewBag.ActionMessage = ActionMessage;

            var GetCurrentStock = await context.CurrentStocks.Where(item => item.Archive == false)
                .Include(item => item.ProductNameNavigation)
                .Include(item => item.AddtionalInfoNavigation)
                .ToListAsync();

            return View(GetCurrentStock);
        }
        public async Task<IActionResult> CreateItem(string ErrorMsg)
        {
            ViewBag.ProductList = await context.StockItems.ToListAsync();
            ViewBag.AdditionalInfo = await context.StockAdditionalInfos.ToListAsync();
            ViewBag.ErrorMsg = ErrorMsg;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateItem(CurrentStock model)
        {
            model.Archive = false;
            model.InputData = DateTime.Now;

            string resultMessage = string.Empty;
            
            await context.AddAsync(model);
            resultMessage = await context.SaveChangesAsync() > 0 
                ? "Dodano poprawie" : string.Empty;


            return RedirectToAction("Index", new { ActionMessage = resultMessage });
        }
        public async Task<IActionResult> UpdateItem(long Id, string ErrorMsg)
        {
            ViewBag.ProductList = await context.StockItems.ToListAsync();
            ViewBag.AdditionalInfo = await context.StockAdditionalInfos.ToListAsync();
            ViewBag.ErrorMsg = ErrorMsg;


            var GetCurrentStock = await context.CurrentStocks.Where(item => item.Id == Id).FirstAsync();

            return View(GetCurrentStock);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateItem(CurrentStock model)
        {
            model.UpdateData = DateTime.Now;


            string resultMessage = string.Empty;

            await Task.Run(() =>
            {
                context.Update(model);
            });
            resultMessage = await context.SaveChangesAsync() > 0 
                ? "Zmieniono poprawnie" : string.Empty;

            return RedirectToAction("Index", new { ActionMessage = resultMessage });
        }
        public async Task<IActionResult> ItemsDetails(long Id)
        {
            var GetItemDetails = await context.CurrentStocks.Where(item => item.Id == Id)
                .Include(item => item.ProductNameNavigation)
                .Include(item => item.AddtionalInfoNavigation)
                .ToListAsync();

            return View(GetItemDetails.First());
        }
        public async Task<IActionResult> DeleteItem(long Id)
        {
            var model = await context.CurrentStocks.Where(item => item.Id == Id).FirstAsync();
            model.Archive = true;


            string resultMessage = string.Empty;
            await Task.Run(() =>
            {
                context.Update(model);
            });
            resultMessage = await context.SaveChangesAsync() > 0 
                ? "Usunięto poprawnie" : string.Empty;

            return RedirectToAction("Index", new { ActionMessage = resultMessage });
        }
        public IActionResult Contact()
            =>
            View();
    }
}