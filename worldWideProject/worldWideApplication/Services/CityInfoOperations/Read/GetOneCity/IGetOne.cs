using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity
{
    public interface IGetOne
    {
        Task<City> City();
    }
}