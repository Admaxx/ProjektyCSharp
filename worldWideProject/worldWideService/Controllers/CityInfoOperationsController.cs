using Autofac;
using Microsoft.AspNetCore.Mvc;
using worldWideApplication.Services.CityInfoOperations.Create.AddOneCity;
using worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion;
using worldWideApplication.Services.CityInfoOperations.Read.GetOneCity;
using worldWideApplication.Services.CityInfoOperations.Read.GetRandomCity;
using worldWideApplication.Services.OptionsForServices;
using worldWideDbModels;

namespace worldWideService.Controllers
{
    [Route("api/[controller]")]
    public class CityInfoOperationsController(MainContainer container) : Controller
    {
        IContainer Conn { get; init; } = container.main(new ContainerBuilder());

        [HttpGet("/GetOneCity")]
        public IActionResult GetOneCity(CityDto city_dto)
        {
            return Ok(Conn.Resolve<IGetOne>().City().Result);
        }
        [HttpPost("/AddOneCity")]
        public IActionResult AddOneCity(City city)
        {
            return Conn.Resolve<IAddOne>().Cities(city).Result ? 
                CreatedAtAction(nameof(AddOneCity), GeneralOptions.CreateSuccessMessage) : BadRequest(GeneralOptions.BadRequestMessage);
        }
        [HttpGet("/GetRandomCity")]
        public IActionResult GetRandomCity()
        {
            return Ok(Conn.Resolve<IGetRandom>().City().Result);
        }
        [HttpGet("/GetAllCitiesByRegion")]
        public IActionResult GetAllCitiesByRegion(Region region)
        {
            return Ok(Conn.Resolve<IGetAll>().Cities(region).Result);
        }
    }
}
