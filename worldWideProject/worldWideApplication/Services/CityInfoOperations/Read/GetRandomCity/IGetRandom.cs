using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetRandomCity
{
    public interface IGetRandom
    {
        Task<City> City();
    }
}