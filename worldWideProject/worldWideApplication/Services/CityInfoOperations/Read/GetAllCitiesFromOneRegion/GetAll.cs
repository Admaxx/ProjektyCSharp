using Autofac;
using worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCities;
using worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCountries;
using worldWideApplication.Services.OptionsForServices;
using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion;

public class GetAll(MainContainer container) : IGetAll
{
    IContainer Conn { get; init; } = container.main(new ContainerBuilder());
    public List<City> AllCities(Region region)
    {
        try
        {
            return Conn.Resolve<IGetAllCities>()
            .AllCitiesByCountries(Conn.Resolve<IGetAllCountries>()
            .AllCountriesByRegion(region).Result);
        }
        catch (Exception ex) { return new List<City>() { new City() { Name = ex.Message } }; }
    }
}
