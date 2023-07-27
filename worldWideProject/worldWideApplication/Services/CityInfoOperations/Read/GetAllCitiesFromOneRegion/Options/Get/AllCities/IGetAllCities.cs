using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCities
{
    public interface IGetAllCities
    {
        List<City> AllCitiesByCountries(List<string> countries);
    }
}