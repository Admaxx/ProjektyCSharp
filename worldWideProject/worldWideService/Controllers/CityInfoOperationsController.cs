using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using worldWideApplication.Services.CityInfoOperations.Create.AddOneCity;
using worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion;
using worldWideApplication.Services.CityInfoOperations.Read.GetOneCity;
using worldWideApplication.Services.CityInfoOperations.Read.GetRandomCity;
using worldWideApplication.Services.OptionsForServices;
using worldWideDbModels;
using worldWideModels.ItemMapperModels;
using worldWideService.GlobalOptions;

namespace worldWideService.Controllers;

public class CityInfoOperationsController(MainContainer container, IMapper mapper, ILogger<CityInfoOperationsController> logger) : Controller
{
    IMapper Mapper { get; init; } = mapper;
    ILogger Logger { get; init; } = logger;
    IContainer Conn { get; init; } = container.main(new ContainerBuilder());

    [HttpGet("/GetOneCity")]
    public IActionResult GetOneCity(CityDto city_dto)
    {
        Logger.LogInformation(CityInfoOperationsOptions.GetOneCityMess);
        return Ok(Mapper.Map<city_dto_AutoMapperModel>(Conn.Resolve<IGetOne>().City(city_dto)));
    }
    [HttpPost("/AddOneCity")]
    public IActionResult AddOneCity(City city)
    {
        Logger.LogInformation(CityInfoOperationsOptions.AddOneCityMess);
        return Conn.Resolve<IAddOne>().City(city).Result ?
            CreatedAtAction(nameof(AddOneCity), CityInfoOperationsOptions.CreateSuccessMessage) : BadRequest(CityInfoOperationsOptions.BadRequestMessage);
    }
    [HttpGet("/GetRandomCity")]
    public IActionResult GetRandomCity()
    {
        Logger.LogInformation(CityInfoOperationsOptions.GetRandomCityMess);
        return Ok(Mapper.Map<city_dto_AutoMapperModel>(Conn.Resolve<IGetRandom>().City()));
    }
    [HttpGet("/GetAllCitiesByRegion")]
    public IActionResult GetAllCitiesByRegion(Region region)
    {
        Logger.LogInformation(CityInfoOperationsOptions.GetAllCitiesByRegionMess);
        return Ok(Mapper.Map<List<city_AutoMapperModel>>(Conn.Resolve<IGetAll>().AllCities(region)));
    }
}

