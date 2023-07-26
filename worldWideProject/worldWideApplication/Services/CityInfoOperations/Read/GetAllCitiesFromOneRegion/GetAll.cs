using Microsoft.EntityFrameworkCore;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion
{
    public class GetAll(WorldWideDbContext context) : IGetAll
    {
        WorldWideDbContext context { get; init; } = context;
        public async Task<List<City>> Cities(Region region)
            => await
            context.Cities.ToListAsync();
    }
}
