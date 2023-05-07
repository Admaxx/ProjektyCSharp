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

        public IActionResult Index(string Message)
        {
            ViewBag.Message = Message;
            return View(context.CurrentStocks.Include(item => item.items));
        }
        public IActionResult CreateItem(string ErrorMsg)
        {
            ViewBag.ProductList = context.StockItems.ToList();
            ViewBag.AdditionalInfo = context.StockAdditionalInfos.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateItem(CurrentStock model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("CreateItem", new { ErrorMsg = "Wystąpił bład" });

            context.Add(model);
            context.SaveChanges();


            return RedirectToAction("Index", new { Message = "Dodano poprawnie" });
        }
    }
}
