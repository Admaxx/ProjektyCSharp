using Autofac;
using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Models;
using CEIDGASPNetCore.Services.CEIDG;
using CEIDGASPNetCore.Services.CEIDG.Interfaces.Abstract;
using CEIDGREGON;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CEIDGASPNetCore.Controllers
{
    public class CEIDGController : Controller
    {
        //Its sometimes hard to refactor code with IoC contrainter
        CeidgregonContext context = null;
        ContrainerResolve resolve = null;

        ConvertDocOnFormat convert = null;
        ProgramGeneralData allData = null;
        public CEIDGController(CeidgregonContext conn, ContrainerResolve ress, ConvertDocOnFormat converts, ProgramGeneralData all )
        {
            this.context = conn;
            this.resolve = ress;

            this.convert = converts;
            this.allData = all;
        }
        public IActionResult Index()
            =>
            View();


        public IActionResult ViewRaportByData(DateTime RaportData)
            =>
            View("Views/CEIDG/Read/ViewRaportByData.cshtml", context.Gusvalues.Where(
                item => 
                item.ImportDate == (RaportData.Date != DateTime.MinValue ? RaportData.Date : DateTime.Now.Date)));
        
        public IActionResult ViewRaportByDateAndType(DateTime RaportData, byte RaportType)
        {
            ViewBag.RaportTypeTable = context.RaportTypeNames;

            return View("Views/CEIDG/Read/ViewRaportByDateAndType.cshtml", context.Gusvalues.Where(
                item => 
                item.RaportType == RaportType && 
                item.ImportDate == (RaportData.Date != DateTime.MinValue ? RaportData.Date : DateTime.Now.Date)));
        }

        public IActionResult ViewLastRaport(bool SetJSONFormat)
        {
            if (context.Gusvalues.IsNullOrEmpty())
                return RedirectToAction(allData.SettingNoRaports, new { MessageFromAction = allData.NoRaportsInDB, ActionToReturn = allData.MainPage });

            ViewBag.IsJSON = SetJSONFormat;

            var RaportModel = context.Gusvalues.OrderBy(item => item.Id).Last();

            RaportModel.Xmlvalues = convert.ChooseFormat(RaportModel.Xmlvalues, SetJSONFormat);
            return View("Views/CEIDG/Read/ViewLastRaport.cshtml", RaportModel);
        }
        public IActionResult AllShowItemsViews()
        {
            if (context.Gusvalues.IsNullOrEmpty())
                return RedirectToAction(allData.SettingNoRaports, new { MessageFromAction = allData.NoRaportsInDB, ActionToReturn = allData.MainPage });

            return View("Views/CEIDG/Read/AllShowItemsViews.cshtml");
        }

        public IActionResult NoRaportsView(string MessageFromAction, string ActionToReturn)
        {
            ViewBag.Message = MessageFromAction;
            ViewBag.ActionNameReturn = ActionToReturn;
            return View("Views/CEIDG/Read/NoRaportsView.cshtml");
        }
        public IActionResult UpdateRaportData(int id)
        {
            return View("Views/CEIDG/Update/UpdateRaportData.cshtml", context.Gusvalues.Where(item => item.Id == id).First());
        }

        [HttpPost]
        public IActionResult UpdateRaportData(Gusvalue model)
        {

            if (model.ImportDate > DateTime.Now.Date)
                return RedirectToAction(allData.SettingNoRaports, new { MessageFromAction = allData.DataGreaterThanTodays, ActionToReturn = allData.LastRaport });

            context.Update(model);
            context.SaveChanges();


            return RedirectToAction(allData.LastRaport, new { SetJSONFormat = false });
        }


        public IActionResult InsertSuccess(Gusvalue LastInsertedValues)
            => 
            View("Views/CEIDG/Create/InsertSuccess.cshtml", LastInsertedValues);
        
        public IActionResult InsertDaneSzukajPodmioty()
            =>
            View("Views/CEIDG/Create/InsertDaneSzukajPodmioty.cshtml");

        [HttpPost]
        public IActionResult InsertDaneSzukajPodmioty(DaneSzukajPodmiotyModel model)
        {
            if (ModelState.IsValid)
            {
                Gusvalue GusValue = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IValuesInsert>().LastInsertValues(0, new List<string>() { model.Regon, model.NIP, model.KRS });

                if (GusValue.Xmlvalues.Contains("ErrorCode"))
                    return RedirectToAction(allData.NotFoundRaportPage, allData.RaiseErrorMessage, GusValue);

                context.Add(GusValue);
                context.SaveChanges();

                return RedirectToAction("InsertSuccess", GusValue);
            }
            return View("Views/CEIDG/Create/InsertDaneSzukajPodmioty.cshtml");
        }
        public IActionResult InsertPelnyRaport()
        {
            ViewBag.RaportsList = context.RaportyNames.Where(item => item.typRaportu == 0).ToList();
            return View("Views/CEIDG/Create/InsertPelnyRaport.cshtml");
        }
        [HttpPost]
        public IActionResult InsertPelnyRaport(DanePobierzPelnyRaport model)
        {
            if (ModelState.IsValid)
            {
                Gusvalue GusValue = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IValuesInsert>().LastInsertValues(1, new List<string>() { model.Regon }, model.NazwaRaportu);

                if (GusValue.Xmlvalues.Contains("ErrorCode"))
                    return RedirectToAction(allData.NotFoundRaportPage, allData.RaiseErrorMessage, GusValue);

                context.Add(GusValue);
                context.SaveChanges();

                return RedirectToAction("InsertSuccess", GusValue);
            }


            return View("Views/CEIDG/Create/InsertPelnyRaport.cshtml");
        }
        public IActionResult InsertRaportZbiorczy()
        {
            ViewBag.RaportsList = context.RaportyNames.Where(item => item.typRaportu == 1).ToList();
            return View("Views/CEIDG/Create/InsertRaportZbiorczy.cshtml");
        }

        [HttpPost]
        public IActionResult InsertRaportZbiorczy(DanePobierzRaportZbiorczy model)
        {
            if (ModelState.IsValid)
            {
                Gusvalue GusValue = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IValuesInsert>().LastInsertValues(2, new List<string>() { model.DataRaportu.ToString("yyyy-MM-dd") }, model.NazwaRaportu );

                if (GusValue.Xmlvalues.Contains("ErrorCode"))
                    return RedirectToAction(allData.NotFoundRaportPage, allData.RaiseErrorMessage, GusValue);

                context.Add(GusValue);
                context.SaveChanges();

                return RedirectToAction("InsertSuccess", GusValue);


            }
            return View("Views/CEIDG/Create/InsertRaportZbiorczy.cshtml");
        }


        public IActionResult DeleteRaportById(long Id, string raportData, byte? controllerChoose, byte? raportType)
        {
            context.Gusvalues.Remove(context.Gusvalues.Where(item => item.Id == Id).First());
            context.SaveChanges();

            if (controllerChoose == 0)
                return RedirectToAction(allData.RaportByData, new { RaportData = Convert.ToDateTime(raportData)});

            else if (controllerChoose == 1)
                return RedirectToAction(allData.RaportByDateAndType, new { RaportData = Convert.ToDateTime(raportData), RaportType = raportType });

            return RedirectToAction(allData.LastRaport, false);

        }
        public IActionResult Privacy()
            =>
            View();
    }
}