using Microsoft.AspNetCore.Mvc;
using CEIDGREGON;
using CEIDGWebApi.Models;
using CEIDGASPNetCore.Services.CEIDG;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using Autofac;

namespace CEIDGWebApi.Controllers
{
    
    public class CEIDGController : ControllerBase
    {
        readonly IContainerResolve resolve = null;

        readonly ProgramGeneralData AllData = null;
        readonly CeidgregonContext context = null;
        readonly FormatOptions convert = null;
        readonly ShowRaportValues show = null;

        byte RaportTypeNo;
        string GetValuesFromInsert;

        public CEIDGController(IContainerResolve container)
        {
            this.resolve = container;

            AllData = resolve.ContainerResolve(new ContainerBuilder()).Resolve<ProgramGeneralData>();
            context = resolve.ContainerResolve(new ContainerBuilder()).Resolve<CeidgregonContext>();
            convert = resolve.ContainerResolve(new ContainerBuilder()).Resolve<FormatOptions>();
            show = resolve.ContainerResolve(new ContainerBuilder()).Resolve<ShowRaportValues>();
            
        }

        [HttpGet]
        [Route("[controller]/GetRaport/{Id}")]
        public async Task<IActionResult> GetRaport(int id)
        {
            try
            {
                return await Task.Run(() => 
                Ok(context.Gusvalues.Where(item => item.Id == id).Single().Xmlvalues));
            }
            catch (InvalidOperationException ex) { return NotFound("Nie znaleziono podanych danych, wybierz inne Id"); }
            catch (Exception e) { return Problem($"Wystąpił błąd: {e}", statusCode: 500); }
        }

        [HttpGet]
        [Route("[controller]/GetRaportByType/{raportType}")]
        public async Task<IActionResult> GetRaportByType(byte raportType)
        {
            try
            {
               return await Task.Run(() => 
               Ok(context.Gusvalues.Where(item => item.RaportType == raportType).
                    OrderByDescending(item => item.Id).Select(item => item.Xmlvalues).ToList()));
            }
            catch (InvalidOperationException ex) { return NotFound("Nie znaleziono podanych danych, wybierz inny typ"); }
            catch (Exception e) { return Problem($"Wystąpił błąd: {e}", statusCode: 500); }

        }

        [HttpGet]
        [Route("[controller]/GetLastRaport/{FormatType?}")]
        public async Task<string> GetLastRaport(bool FormatType)
        {
            var RaportModel = context.Gusvalues.OrderBy(item => item.Id).Last();

            return await Task.Run(() => 
            convert.ChooseFormat(RaportModel.Xmlvalues, FormatType));
        }


        [HttpGet]
        [Route("[controller]/GetRaportByDate/{Date}")]
        public async Task<IActionResult> GetRaportByDate(DateTime Date)
        {
            try
            {
                return await Task.Run(() => 
                Ok(context.Gusvalues.Where(item => item.ImportDate == Date).
                OrderByDescending(item => item.Id).Select(item => item.Xmlvalues).ToList()));
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
                await Task.Run(() => context.Gusvalues.Where(item => item.Id == id).Single().Xmlvalues = UpdatedValue);
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

            await Task.Run(() =>
            {
                RaportTypeNo = AllData.RaportTypes[RaportName];

                GetValuesFromInsert = show.GetValuesFromGus(Value, RaportTypeNo, NazwaRaportu);
            });
            
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
                await Task.Run(() => context.Remove(context.Gusvalues.Where(item => item.Id == id).First()));
                await context.SaveChangesAsync();

                return Ok($"Usunięto dane o indeksie {id}");
            }
            catch (InvalidOperationException ex) { return NotFound("Nie znaleziono podanych danych, wybierz inne Id"); }
            catch (Exception e) { return Problem($"Wystąpił błąd: {e}", statusCode: 500); }
        }
    }
}