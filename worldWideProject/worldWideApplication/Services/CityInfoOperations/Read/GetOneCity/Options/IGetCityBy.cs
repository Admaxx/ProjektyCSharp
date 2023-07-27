using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity.Options
{
    public interface IGetCityBy
    {
        Task<City> GetOneCityByParams(CityDto city_dto);
    }
}