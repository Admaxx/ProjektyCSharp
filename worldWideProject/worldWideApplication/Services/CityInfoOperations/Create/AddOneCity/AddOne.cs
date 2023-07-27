using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Create.AddOneCity
{
    public class AddOne(WorldWideDbContext context) : IAddOne
    {
        WorldWideDbContext Context { get; init; } = context;
        public async Task<bool> Cities(City city)
        {
            await Context.Cities.AddAsync(city);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
