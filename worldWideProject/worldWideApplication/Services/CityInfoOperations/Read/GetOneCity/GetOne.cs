using Microsoft.EntityFrameworkCore;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity
{
    public class GetOne(WorldWideDbContext context) : IGetOne
    {
        WorldWideDbContext context { get; init; } = context;
        public async Task<City> City()
            => await
            context.Cities.OrderBy(item => Guid.NewGuid()).FirstAsync();


    }
}
