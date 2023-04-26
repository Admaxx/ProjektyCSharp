using Autofac;
using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Models;
using CEIDGASPNetCore.Services.CEIDG.Interfaces.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using CEIDGREGON;
using CEIDGASPNetCore.Services.CEIDG.Abstract;

namespace CEIDGASPNetCore.Controllers
{
    public class CEIDGController : Controller
    {
        //Its sometimes hard to refactor code with IoC contrainter
        readonly IContainerResolve resolve = null;

        readonly ProgramGeneralData allData = null;
        readonly CeidgregonContext context = null;
        readonly FormatOptions convert = null;
        public CEIDGController(IContainerResolve container)
        {
            this.resolve = container;

            allData = resolve.ContainerResolve(new ContainerBuilder()).Resolve<ProgramGeneralData>();
            context = resolve.ContainerResolve(new ContainerBuilder()).Resolve<CeidgregonContext>();
            convert = resolve.ContainerResolve(new ContainerBuilder()).Resolve<FormatOptions>();
        }
        public async Task<IActionResult> Index()
            =>
            await Task.Run(() => View());


        public async Task<IActionResult> ViewRaportByData(DateTime RaportData)
            => await Task.Run(() => 
            View("Views/CEIDG/Read/ViewRaportByData.cshtml", context.Gusvalues.Where(
                item => 
                item.ImportDate == (RaportData.Date != DateTime.MinValue ? RaportData.Date : DateTime.Now.Date))));
        
        public async Task<IActionResult> ViewRaportByDateAndType(DateTime RaportData, byte RaportType)
        {
            ViewBag.RaportTypeTable = context.RaportTypeNames;

            return await Task.Run(() => 
            View("Views/CEIDG/Read/ViewRaportByDateAndType.cshtml", context.Gusvalues.Where(
                item => 
                item.RaportType == RaportType && 
                item.ImportDate == (RaportData.Date != DateTime.MinValue ? RaportData.Date : DateTime.Now.Date))));
        }

        public async Task<IActionResult> ViewLastRaport(bool SetJSONFormat)
        {
            if (context.Gusvalues.IsNullOrEmpty())
                return await Task.Run(() => 
                RedirectToAction(allData.SettingNoRaports, new { MessageFromAction = allData.NoRaportsInDB, ActionToReturn = allData.MainPage }));

            ViewBag.IsJSON = SetJSONFormat;

            var RaportModel = context.Gusvalues.OrderBy(item => item.Id).Last();

            RaportModel.Xmlvalues = convert.ChooseFormat(RaportModel.Xmlvalues, SetJSONFormat);
            return await Task.Run(() => 
            View("Views/CEIDG/Read/ViewLastRaport.cshtml", RaportModel));
        }
        public async Task<IActionResult> AllShowItemsViews()
        {
            if (context.Gusvalues.IsNullOrEmpty())
                return await Task.Run(() => 
                RedirectToAction(allData.SettingNoRaports, new { MessageFromAction = allData.NoRaportsInDB, ActionToReturn = allData.MainPage }));
            

            return await Task.Run(() => 
            View("Views/CEIDG/Read/AllShowItemsViews.cshtml"));
        }

        public async Task<IActionResult> NoRaportsView(string MessageFromAction, string ActionToReturn)
        {
            ViewBag.Message = MessageFromAction;
            ViewBag.ActionNameReturn = ActionToReturn;
            return await Task.Run(() =>
                View("Views/CEIDG/Read/NoRaportsView.cshtml"));
        }
        public async Task<IActionResult> UpdateRaportData(int id)
        {
            return await Task.Run(() =>
                View("Views/CEIDG/Update/UpdateRaportData.cshtml", context.Gusvalues.Where(item => item.Id == id).First()));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRaportData(Gusvalue model)
        {

            if (model.ImportDate > DateTime.Now.Date)
                return await Task.Run(() => 
                RedirectToAction(allData.SettingNoRaports, new { MessageFromAction = allData.DataGreaterThanTodays, ActionToReturn = allData.LastRaport }));

            await Task.Run(() => context.Update(model));
            await context.SaveChangesAsync();


            return await Task.Run(() => RedirectToAction(allData.LastRaport, new { SetJSONFormat = false }));
        }


        public async Task<IActionResult> InsertSuccess(Gusvalue LastInsertedValues)
            => await Task.Run(() =>
            View("Views/CEIDG/Create/InsertSuccess.cshtml", LastInsertedValues));
        
        public async Task<IActionResult> InsertDaneSzukajPodmioty()
            => await Task.Run(() =>
            View("Views/CEIDG/Create/InsertDaneSzukajPodmioty.cshtml"));

        [HttpPost]
        public async Task<IActionResult> InsertDaneSzukajPodmioty(DaneSzukajPodmiotyModel model)
        {
            if (!ModelState.IsValid)
                return await Task.Run(() =>
                View("Views/CEIDG/Create/InsertDaneSzukajPodmioty.cshtml"));
            


            Gusvalue GusValue = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IValuesInsert>().LastInsertValues(0, new List<string>() { model.Regon, model.NIP, model.KRS });

            if (GusValue.Xmlvalues.Contains("ErrorCode"))
                return await Task.Run(() =>  
                RedirectToAction(allData.NotFoundRaportPage, allData.RaiseErrorMessage, GusValue));

            await context.AddAsync(GusValue);
            await context.SaveChangesAsync();

            return await Task.Run(() => 
            RedirectToAction("InsertSuccess", GusValue));


        }
        public async Task<IActionResult> InsertPelnyRaport()
        {
            ViewBag.RaportsList = context.RaportyNames.Where(item => item.typRaportu == 0).ToList();
            return await Task.Run(() => 
            View("Views/CEIDG/Create/InsertPelnyRaport.cshtml"));
        }
        [HttpPost]
        public async Task<IActionResult> InsertPelnyRaport(DanePobierzPelnyRaport model)
        {
            if (!ModelState.IsValid)
                return await Task.Run(() =>
                RedirectToAction("InsertPelnyRaport"));
            
            Gusvalue GusValue = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IValuesInsert>().LastInsertValues(1, new List<string>() { model.Regon }, model.NazwaRaportu);

            if (GusValue.Xmlvalues.Contains("ErrorCode"))
                return await Task.Run(() => 
                RedirectToAction(allData.NotFoundRaportPage, allData.RaiseErrorMessage, GusValue));

            await context.AddAsync(GusValue);
            await context.SaveChangesAsync();

            return await Task.Run(() =>
            RedirectToAction("InsertSuccess", GusValue));
        }
        public async Task<IActionResult> InsertRaportZbiorczy()
        {
            ViewBag.RaportsList = context.RaportyNames.Where(item => item.typRaportu == 1).ToList();
            return await Task.Run(() => 
            View("Views/CEIDG/Create/InsertRaportZbiorczy.cshtml"));
        }

        [HttpPost]
        public async Task<IActionResult> InsertRaportZbiorczy(DanePobierzRaportZbiorczy model)
        {
            if (!ModelState.IsValid)
                return await Task.Run(() =>
                View("Views/CEIDG/Create/InsertRaportZbiorczy.cshtml"));
            

            Gusvalue GusValue = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IValuesInsert>().LastInsertValues(2, new List<string>() { model.DataRaportu.ToString("yyyy-MM-dd") }, model.NazwaRaportu);

            if (GusValue.Xmlvalues.Contains("ErrorCode"))
                return await Task.Run(() => 
                RedirectToAction(allData.NotFoundRaportPage, allData.RaiseErrorMessage, GusValue));

            await context.AddAsync(model);
            await context.SaveChangesAsync();

            return await Task.Run(() => 
            RedirectToAction("InsertSuccess", GusValue));

        }


        public async Task<IActionResult> DeleteRaportById(long Id, string raportData, byte? controllerChoose, byte? raportType)
        {
            context.Gusvalues.Remove(context.Gusvalues.Where(item => item.Id == Id).First());
            await context.SaveChangesAsync();

            if (controllerChoose == 0)
                return await Task.Run(() => 
                RedirectToAction(allData.RaportByData, new { RaportData = Convert.ToDateTime(raportData)}));

            else if (controllerChoose == 1)
                return await Task.Run(() => 
                RedirectToAction(allData.RaportByDateAndType, new { RaportData = Convert.ToDateTime(raportData), RaportType = raportType }));

            return await Task.Run(() => 
            RedirectToAction(allData.LastRaport, false));

        }
        public async Task<IActionResult> Privacy()
            =>
            await Task.Run(() => View());
    }
}