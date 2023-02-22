using Microsoft.AspNetCore.Mvc;
using CEIDGWebApi.Model;
using CEIDGREGON;
using ServiceReference1;
using CEIDGWebApi.Models;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace CEIDGWebApi.Controllers
{
    
    public class CEIDGController : ControllerBase
    {
        CeidgregonContext context;

        ProgramGeneralData AllData;
        ShowRaportValues show;

        byte RaportTypeNo;
        string GetValuesFromInsert;

        public CEIDGController() 
        {
            context = new CeidgregonContext();

            AllData = new ProgramGeneralData();
            show = new ShowRaportValues();
        }

        [HttpGet]
        [Route("[controller]/GetRaportByType/{raportType}")]
        public List<string> GetRaportByType(byte raportType)
            =>
            context.Gusvalues.Where(item => item.RaportType == raportType).
                OrderByDescending(item => item.Id).Select(item => item.Xmlvalues).ToList();
        

        [HttpGet]
        [Route("[controller]/GetRaportByDate/{Date}/{raportType?}")]
        public List<string> GetRaportByDate(DateTime Date, byte raportType)
            => 
            context.Gusvalues.Where(item => item.ImportDate == Date && item.RaportType == raportType).
                OrderByDescending(item => item.Id).Select(item => item.Xmlvalues).ToList();


        [HttpGet]
        [Route("[controller]/GetRaport/{Id}")]
        public string GetRaport(int id)
        {
            try
            {
                return context.Gusvalues.Where(item => item.Id == id).Single().Xmlvalues;
            }
            catch (InvalidOperationException ex) { return "Nie znaleziono podanych danych, wybierz inne Id"; }
            catch (Exception e) { }

            return string.Empty;
        }

        [HttpPut]
        [Route("[controller]/UpdateRaport/{Id}/{UpdatedValue}")]
        public string UpdateRaport(int id, string UpdatedValue)
        {
            try
            {
                context.Gusvalues.Where(item => item.Id == id).Single().Xmlvalues = UpdatedValue;
                context.SaveChanges();
            }
            catch (InvalidOperationException ex) { return "Nie znaleziono podanych danych, wybierz inne Id"; }
            catch (Exception e) { }

            return $"Zmieniono dane o indeksie {id}";
        }

        [HttpPost]
        [Route("[controller]/InsertRaport/{RaportName}/{Value}/{NazwaRaportu?}")]
        public string InsertRaport(string RaportName, string Value, string? NazwaRaportu)
        {
            if (!AllData.RaportTypes.ContainsKey($"{RaportName}"))
                return "Nie znaleziono podanego raportu, sprawdź swoją pisownię...";

            RaportTypeNo = AllData.RaportTypes[RaportName];

            GetValuesFromInsert = show.GetValuesAndInsertToDB(Value, RaportTypeNo, NazwaRaportu);
            

            context.Add(new Gusvalue() { Xmlvalues = GetValuesFromInsert, ImportDate = DateTime.Now, RaportType = RaportTypeNo });
            context.SaveChanges();

            return GetValuesFromInsert;
        }
        [HttpDelete]
        [Route("[controller]/DeleteRaport/{Id}")]
        public string DeleteRaport(int id)
        {
            try
            {
                context.Remove(context.Gusvalues.Where(item => item.Id == id).First());
                context.SaveChanges();
            }
            catch (InvalidOperationException ex) { return "Podany model, jest pusty. Wybierz inne id"; }
            catch (Exception e) { }

            return $"Usunięto dane o indeksie {id}";
        }
    }
}