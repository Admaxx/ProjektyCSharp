using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity
{
    public interface IGetOne
    {
        CityDto City(CityDto city_dto);
    }
}