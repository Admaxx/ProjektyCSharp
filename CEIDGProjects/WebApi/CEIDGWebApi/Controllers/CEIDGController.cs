using Microsoft.AspNetCore.Mvc;
using CEIDGREGON;
using CEIDGWebApi.Models;
using CEIDGASPNetCore.Services.CEIDG;

namespace CEIDGWebApi.Controllers
{
    
    public class CEIDGController : ControllerBase
    {
        CeidgregonContext context;
        ConvertDocOnFormat convert;

        ProgramGeneralData AllData;
        ShowRaportValues show;

        byte RaportTypeNo;
        string GetValuesFromInsert;

        public CEIDGController(CeidgregonContext context, ProgramGeneralData program, ShowRaportValues raports) 
        {
            this.context = context;
            this.show = raports;
            this.AllData = program;
            
        }

        [HttpGet]
        [Route("[controller]/GetRaport/{Id}")]
        public IActionResult GetRaport(int id)
        {
            try
            {
                return Ok(context.Gusvalues.Where(item => item.Id == id).Single().Xmlvalues);
            }
            catch (InvalidOperationException ex) { return NotFound("Nie znaleziono podanych danych, wybierz inne Id"); }
            catch (Exception e) { return Problem($"Wystąpił błąd: {e}", statusCode: 500); }
        }

        [HttpGet]
        [Route("[controller]/GetRaportByType/{raportType}")]
        public IActionResult GetRaportByType(byte raportType)
        {
            try
            {
               return Ok(context.Gusvalues.Where(item => item.RaportType == raportType).
                    OrderByDescending(item => item.Id).Select(item => item.Xmlvalues).ToList());
            }
            catch (InvalidOperationException ex) { return NotFound("Nie znaleziono podanych danych, wybierz inny typ"); }
            catch (Exception e) { return Problem($"Wystąpił błąd: {e}", statusCode: 500); }

        }

        [HttpGet]
        [Route("[controller]/GetLastRaport/{FormatType?}")]
        public string GetLastRaport(bool FormatType)
        {
            convert = new ConvertDocOnFormat(FormatType);
            return convert.ChooseFormat(context.Gusvalues.OrderBy(item => item.Id).Last().Xmlvalues);
        }


        [HttpGet]
        [Route("[controller]/GetRaportByDate/{Date}")]
        public IActionResult GetRaportByDate(DateTime Date)
        {
            try
            {
                return Ok(context.Gusvalues.Where(item => item.ImportDate == Date).
                OrderByDescending(item => item.Id).Select(item => item.Xmlvalues).ToList());
            }
            catch (InvalidOperationException ex) { return NotFound("Nie znaleziono podanych danych, wybierz inny typ"); }
            catch (Exception e) { return Problem($"Wystąpił błąd: {e}", statusCode: 500); }

        }

        [HttpPut]
        [Route("[controller]/UpdateRaport/{Id}/{UpdatedValue}")]
        public async Task<IActionResult> UpdateRaport(int id, string UpdatedValue)
        {
            try
            {
                context.Gusvalues.Where(item => item.Id == id).Single().Xmlvalues = UpdatedValue;
                await context.SaveChangesAsync();

                return Ok($"Zmieniono dane o indeksie {id}");
            }
            catch (InvalidOperationException ex) { return NotFound("Nie znaleziono podanych danych, wybierz inne Id"); }
            catch (Exception e) { return Problem($"Wystąpił błąd: {e}", statusCode: 500); }
        }

        [HttpPost]
        [Route("[controller]/InsertRaport/{RaportName}/{Value}/{NazwaRaportu?}")]
        public async Task<IActionResult> InsertRaport(string RaportName, string Value, string? NazwaRaportu)
        {
            if (!AllData.RaportTypes.ContainsKey($"{RaportName}"))
                return NotFound("Nie znaleziono podanego raportu, sprawdź swoją pisownię...");

            RaportTypeNo = AllData.RaportTypes[RaportName];

            GetValuesFromInsert = show.GetValuesFromGus(Value, RaportTypeNo, NazwaRaportu);
            
            await context.AddAsync(new Gusvalue() { Xmlvalues = GetValuesFromInsert, ImportDate = DateTime.Now, RaportType = RaportTypeNo });
            await context.SaveChangesAsync();

            return Ok($"Wpisano poprawnie do bazy");
        }

        [HttpDelete]
        [Route("[controller]/DeleteRaport/{Id}")]
        public async Task<IActionResult> DeleteRaport(int id)
        {
            try
            {
                context.Remove(context.Gusvalues.Where(item => item.Id == id).First());
                await context.SaveChangesAsync();

                return Ok($"Usunięto dane o indeksie {id}");
            }
            catch (InvalidOperationException ex) { return NotFound("Nie znaleziono podanych danych, wybierz inne Id"); }
            catch (Exception e) { return Problem($"Wystąpił błąd: {e}", statusCode: 500); }
        }
    }
}