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
            if (!ModelState.IsValid)
                return RedirectToAction("CreateItem", new { ErrorMsg = "Wystąpił bład" });

            model.Archive = false;
            model.InputData = DateTime.Now;

            await context.AddAsync(model);
            await context.SaveChangesAsync();


            return RedirectToAction("Index", new { ActionMessage = "Dodano poprawnie" });
        }
        public async Task<IActionResult> UpdateItem(long Id, string ErrorMsg)
        {
            ViewBag.ProductList = await context.StockItems.ToListAsync();
            ViewBag.AdditionalInfo = await context.StockAdditionalInfos.ToListAsync();
            ViewBag.ErrorMsg = ErrorMsg;

            return View(await context.CurrentStocks.Where(item => item.Id == Id).FirstAsync());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateItem(CurrentStock model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("UpdateItem", new { model.Id, ErrorMsg = "Wystąpił bład" });

            model.UpdateData = DateTime.Now;
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
            var model = await context.CurrentStocks.Where(item => item.Id == Id).FirstAsync();

            model.Archive = true;
            await Task.Run(() =>
            {
                context.Update(model);
            });
            await context.SaveChangesAsync();

            return RedirectToAction("Index", new { ActionMessage = "Usunięto poprawnie" });
        }
        public IActionResult Privacy()
            =>
            View();
    }
}
