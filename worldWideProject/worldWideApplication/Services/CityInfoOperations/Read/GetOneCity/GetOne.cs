using Autofac;
using worldWideApplication.Services.CityInfoOperations.Read.GetOneCity.Options;
using worldWideApplication.Services.OptionsForServices;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity
{
    public class GetOne(MainContainer container) : IGetOne
    {
        IContainer Conn { get; init; } = container.main(new ContainerBuilder());
        public CityDto City(CityDto city_dto)
        {
            try
            {
                var OneCityInfo = Conn.Resolve<IGetCityBy>().GetOneCityByParams(city_dto).Result;
                return new CityDto()
                {
                    Name = OneCityInfo.Name,
                    Population = OneCityInfo.Population,
                    Country = OneCityInfo.Country,
                    Region = Conn.Resolve<IGetRegion>().RegionByString(OneCityInfo.Country)
                };
            }catch (Exception ex) { return new CityDto() { Name = ex.Message }; }
        }
    }
}
