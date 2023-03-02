using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Models;
using CEIDGASPNetCore.Services.CEIDG;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CEIDGASPNetCore.Controllers
{
    public class CEIDGController : Controller
    {
        CeidgregonContext context;
        GetInsertValues Get;
        ConvertDocOnFormat convert;
        public CEIDGController()
        {
            context = new CeidgregonContext();
            Get = new GetInsertValues();
        }
        public IActionResult Index()
            =>
            View();

        public IActionResult ViewRaportByDateAndType(DateTime RaportDate, byte RaportType)
        {
            ViewBag.RaportTypeTable = context.RaportTypeNames;
            return View(context.Gusvalues.Where(item => item.RaportType == RaportType && item.ImportDate == RaportDate));
        }
        
        public IActionResult ViewLastRaport(bool SetJSONFormat)
        {
            ViewBag.IsJSON = SetJSONFormat;

            if (context.Gusvalues.IsNullOrEmpty())
                return RedirectToAction("EmptyView");


            var RaportModel = context.Gusvalues.OrderBy(item => item.Id).Last();
            convert = new ConvertDocOnFormat(SetJSONFormat);

            RaportModel.Xmlvalues = convert.ChooseFormat(RaportModel.Xmlvalues);
            return View(RaportModel);
        }
        public IActionResult ViewRaportByData(DateTime RaportDate)
            =>        
            View(context.Gusvalues.Where(item => item.ImportDate == RaportDate.Date).ToList());
        
        public IActionResult InsertSuccess(Gusvalue LastInsertedValues)
            => 
            View(LastInsertedValues);
        
        public IActionResult InsertDaneSzukajPodmioty()
            =>
            View();
        

        [HttpPost]
        public IActionResult InsertDaneSzukajPodmioty(DaneSzukajPodmiotyModel model)
        {
            if (ModelState.IsValid)
            {
                Gusvalue GusValue = Get.LastInsertValues(0, new List<string>() { model.Regon, model.NIP, model.KRS });

                context.Add(GusValue);
                context.SaveChanges();

                return RedirectToAction("InsertSuccess", GusValue);
            }
            return View();
        }
        public IActionResult InsertPelnyRaport()
            =>
            View();
        [HttpPost]
        public IActionResult InsertPelnyRaport(DanePobierzPelnyRaport model)
        {

            if (ModelState.IsValid)
            {
                Gusvalue GusValue = Get.LastInsertValues(1, new List<string>() { model.Regon }, model.NazwaRaportu);

                context.Add(GusValue);
                context.SaveChanges();

                return RedirectToAction("InsertSuccess", GusValue);
            }


            return View();
        }
        public IActionResult InsertRaportZbiorczy()
            =>
            View();

        [HttpPost]
        public IActionResult InsertRaportZbiorczy(DanePobierzRaportZbiorczy model)
        {
            if (ModelState.IsValid)
            {
                Gusvalue GusValue = Get.LastInsertValues(2, new List<string>() { model.DataRaportu.ToString("yyyy-MM-dd") }, model.NazwaRaportu );

                context.Add(GusValue);
                context.SaveChanges();

                return RedirectToAction("InsertSuccess", GusValue);
            }
            return View();
        }

        public IActionResult DeleteLastRaport(int lastId)
        {
            if (ModelState.IsValid)
            {
                context.Gusvalues.Remove(context.Gusvalues.Where(item => item.Id == lastId).First());
                context.SaveChanges();
            }
            return RedirectToAction("ViewLastRaport", false);
        }
        public IActionResult NoRaportsView()
            => 
            View();
        public IActionResult AllShowItemsViews()
        {
            return View();
        }

    }
}