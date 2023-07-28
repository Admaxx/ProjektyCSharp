using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCountries;

public interface IGetAllCountries
{
    Task<List<string>> AllCountriesByRegion(Region region);
}
