using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Controllers
{
    public class CurrentWarehouseController : Controller
    {
        PaperWarehouseContext context;

        public CurrentWarehouseController(PaperWarehouseContext _context)
            =>
            this.context = _context;
        
        public IActionResult Index(string ActionMessage)
        {
            var GetCurrentStock = context.CurrentStocks.Where(item => item.Archive == false);
            ViewBag.ActionMessage = ActionMessage;
            return View(GetCurrentStock);
        }
        public IActionResult CreateItem(string ErrorMsg)
        {
            ViewBag.ProductList = context.StockItems.ToListAsync();
            ViewBag.AdditionalInfo = context.StockAdditionalInfos.ToListAsync();
            ViewBag.ErrorMsg = ErrorMsg;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateItem(CurrentStock model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("CreateItem", new { ErrorMsg = "Wystąpił bład" });

            await context.AddAsync(model);
            await context.SaveChangesAsync();


            return RedirectToAction("Index", new { ActionMessage = "Dodano poprawnie" });
        }
        public IActionResult UpdateItem(long Id, string ErrorMsg)
        {
            ViewBag.ProductList = context.StockItems.ToListAsync();
            ViewBag.AdditionalInfo = context.StockAdditionalInfos.ToListAsync();
            ViewBag.ErrorMsg = ErrorMsg;

            return View(context.CurrentStocks.Where(item => item.Id == Id).FirstAsync());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateItem(CurrentStock model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("UpdateItem", new { model.Id, ErrorMsg = "Wystąpił bład" });

            await Task.Run(() =>
            {
                context.Update(model);
            });
            await context.SaveChangesAsync();

            return RedirectToAction("Index", new { ActionMessage = "Zmieniono poprawnie" });
        }
        public IActionResult ItemsDetails(long Id)
            =>
            View(context.CurrentStocks.Where(item => item.Id == Id).First());
        
        public async Task<IActionResult> DeleteItem(long Id)
        {
            
            await Task.Run(() =>
            {
                context.Remove(context.CurrentStocks.Where(item => item.Id == Id).FirstAsync());
            });
            await context.SaveChangesAsync();

            return RedirectToAction("Index", new { ActionMessage = "Usunięto poprawnie" });
        }
    }
}
