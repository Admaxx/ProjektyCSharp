using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion
{
    public interface IGetAll
    {
        Task<List<City>> Cities(Region region);
    }
}