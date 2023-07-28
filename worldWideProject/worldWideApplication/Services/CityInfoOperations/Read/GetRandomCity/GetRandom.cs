using Autofac;
using Microsoft.EntityFrameworkCore;
using worldWideApplication.Services.CityInfoOperations.Read.GetOneCity.Options;
using worldWideApplication.Services.OptionsForServices;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetRandomCity;

public class GetRandom(WorldWideDbContext context, MainContainer container) : IGetRandom
{
    WorldWideDbContext context { get; init; } = context;
    IContainer Conn { get; init; } = container.main(new ContainerBuilder());
    public CityDto City()
    {
        var randomCity = context.Cities.OrderBy(item => Guid.NewGuid()).FirstAsync().Result;

        return new CityDto()
        {
            Name = randomCity.Name,
            Population = randomCity.Population,
            Country = randomCity.Country,
            Region = Conn.Resolve<IGetRegion>().RegionByCountry(randomCity.Country)
        };

    }


}