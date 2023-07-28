using Autofac;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCities;

public class GetAllCities(WorldWideDbContext context) : IGetAllCities
{
    WorldWideDbContext Context { get; init; } = context;
    public List<City> AllCitiesByCountries(List<string> countries)
        =>
        Context.Cities.Where(item => countries.Any(items => items == item.Country))
        .OrderBy(item => item.Country)
        .ToList();
}