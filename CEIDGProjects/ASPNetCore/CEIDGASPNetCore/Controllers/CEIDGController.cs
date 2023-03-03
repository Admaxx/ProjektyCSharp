﻿using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Models;
using CEIDGASPNetCore.Services.CEIDG;
using CEIDGREGON;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CEIDGASPNetCore.Controllers
{
    public class CEIDGController : Controller
    {
        CeidgregonContext context;
        GetInsertValues Get;
        ConvertDocOnFormat convert;
        ProgramGeneralData allData;
        public CEIDGController()
        {
            context = new CeidgregonContext();
            Get = new GetInsertValues();
            allData = new ProgramGeneralData();
        }
        public IActionResult Index()
            =>
            View();

        public IActionResult ViewRaportByData(DateTime RaportData)
            => 
            View("Views/CEIDG/Read/ViewRaportByData.cshtml", context.Gusvalues.Where(item => item.ImportDate == RaportData.Date).ToList());
        
        
        public IActionResult ViewRaportByDateAndType(DateTime RaportData, byte RaportType)
        {
            ViewBag.RaportTypeTable = context.RaportTypeNames;
            return View("Views/CEIDG/Read/ViewRaportByDateAndType.cshtml", context.Gusvalues.Where(item => item.RaportType == RaportType && item.ImportDate == RaportData.Date));
        }

        public IActionResult ViewLastRaport(bool SetJSONFormat)
        {
            ViewBag.IsJSON = SetJSONFormat;

            var RaportModel = context.Gusvalues.OrderBy(item => item.Id).Last();
            convert = new ConvertDocOnFormat(SetJSONFormat);

            RaportModel.Xmlvalues = convert.ChooseFormat(RaportModel.Xmlvalues);
            return View("Views/CEIDG/Read/ViewLastRaport.cshtml", RaportModel);
        }
        public IActionResult AllShowItemsViews()
        {
            if (context.Gusvalues.IsNullOrEmpty())
                return RedirectToAction("NoRaportsView", new { MessageFromAction = "Nie zostały wystawione żadne raporty", ActionToReturn = "Index" });

            return View("Views/CEIDG/Read/AllShowItemsViews.cshtml");
        }

        public IActionResult NoRaportsView(string MessageFromAction, string ActionToReturn)
        {
            ViewBag.Message = MessageFromAction;
            ViewBag.ActionNameReturn = ActionToReturn;
            return View("Views/CEIDG/Read/NoRaportsView.cshtml");
        }

        public IActionResult UpdateRaportData(Gusvalue model)
        {
            if (!ModelState.IsValid)
                return View("Views/CEIDG/Update/UpdateRaportData.cshtml", context.Gusvalues.Where(item => item.Id == model.Id).First());
            
            if (model.ImportDate > DateTime.Now.Date)
                return RedirectToAction("NoRaportsView", new { MessageFromAction = "Data nie może być większa, od dzisiejszej!", ActionToReturn = "ViewLastRaport" });

            
            context.Update(model);
            context.SaveChanges();


            return RedirectToAction("ViewLastRaport", new { SetJSONFormat = false });
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
                Gusvalue GusValue = Get.LastInsertValues(0, new List<string>() { model.Regon, model.NIP, model.KRS });

                if (GusValue.Xmlvalues.Contains("ErrorCode"))
                    return RedirectToAction("RaportNotFound", "CEIDGErrorHandling", GusValue);

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
                Gusvalue GusValue = Get.LastInsertValues(1, new List<string>() { model.Regon }, model.NazwaRaportu);

                if (GusValue.Xmlvalues.Contains("ErrorCode"))
                    return RedirectToAction("RaportNotFound", "CEIDGErrorHandling", GusValue);

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
                Gusvalue GusValue = Get.LastInsertValues(2, new List<string>() { model.DataRaportu.ToString("yyyy-MM-dd") }, model.NazwaRaportu );

                if (GusValue.Xmlvalues.Contains("ErrorCode"))
                    return RedirectToAction("RaportNotFound","CEIDGErrorHandling", GusValue);

                context.Add(GusValue);
                context.SaveChanges();

                return RedirectToAction("InsertSuccess", GusValue);


            }
            return View("Views/CEIDG/Create/InsertRaportZbiorczy.cshtml");
        }


        public IActionResult DeleteRaportById(long Id, DateTime raportData, byte? controllerChoose, byte? raportType)
        {
            string GetActionName = allData.RaportByData;
            if (controllerChoose == 1)
                GetActionName = allData.RaportByDateAndType;

            context.Gusvalues.Remove(context.Gusvalues.Where(item => item.Id == Id).First());
            context.SaveChanges();

            return RedirectToAction(GetActionName, new { RaportData = raportData.ToString("dd-MM-yyyy"), RaportType = raportType });
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
        public IActionResult Privacy()
            =>
            View();
    }
}