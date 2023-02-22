using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Models;
using CEIDGASPNetCore.Services.CEIDG;
using Microsoft.AspNetCore.Mvc;

namespace CEIDGASPNetCore.Controllers
{
    public class CEIDGController : Controller
    {
        CeidgregonContext context;
        GetInsertValues Get;
        public CEIDGController()
        {
            context = new CeidgregonContext();
            Get = new GetInsertValues();

        }
        public IActionResult ViewLastRaport()
        {
            return View(context.Gusvalues.OrderBy(item => item.Id).Last());
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
