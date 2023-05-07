using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Controllers
{
    public class CurrentWarehouseController : Controller
    {
        PaperWarehouseContext context;

        public CurrentWarehouseController(PaperWarehouseContext _context)
        {
            this.context = _context;
        }

        public IActionResult Index(string ActionMessage)
        {
            var GetCurrentStock = context.CurrentStocks.Where(item => item.Archive == false);
            ViewBag.ActionMessage = ActionMessage;
            return View(GetCurrentStock);
        }
        public IActionResult CreateItem(string ErrorMsg)
        {
            ViewBag.ProductList = context.StockItems.ToList();
            ViewBag.AdditionalInfo = context.StockAdditionalInfos.ToList();
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
        public async Task<IActionResult> DeleteItem(long Id)
        {
            
            await Task.Run(() =>
            {
                context.Remove(context.CurrentStocks.Where(item => item.Id == Id).First());
            });
            await context.SaveChangesAsync();

            return RedirectToAction("Index", new { ActionMessage = "Usunięto poprawnie" });
        }
    }
}
