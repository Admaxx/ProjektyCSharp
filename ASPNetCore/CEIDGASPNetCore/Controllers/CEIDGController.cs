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
        Handling handlingErrors;
        public CEIDGController()
        {
            context = new CeidgregonContext();
            Get = new GetInsertValues();
        }
        public IActionResult Index()
        {
            return View();
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
        {
            return View(context.Gusvalues.Where(item => item.ImportDate == RaportDate.Date).ToList());
        }
        public IActionResult InsertSuccess(Gusvalue LastInsertedValues)
        {
            return View(LastInsertedValues);
        }
        public IActionResult InsertDaneSzukajPodmioty()
        {
            return View();
        }

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
        {
            return View();
        }
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
        {
            return View();
        }
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
        public IActionResult GetGusErrorMess(string SpecialMessageText)
        {
            if (!string.IsNullOrEmpty(SpecialMessageText))
            {
                handlingErrors = new Handling();

                ViewBag.ErrorMessage = handlingErrors.GetErrorMessage(SpecialMessageText);
            }
            return View(context.GusSpecialMessages);
        }
        public IActionResult NoRaportsView()
        {
            return View();
        }
    }
}