using Microsoft.EntityFrameworkCore;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetRandomCity
{
    public class GetRandom(WorldWideDbContext context) : IGetRandom
    {
        WorldWideDbContext context { get; init; } = context;
        public async Task<City> City()
            => await
            context.Cities.OrderBy(item => Guid.NewGuid()).FirstAsync();


    }
}
