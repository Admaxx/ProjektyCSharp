using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion;

public interface IGetAll
{
    List<City> AllCities(Region region);
}
