using Autofac;
using worldWideApplication.Services.OptionsForServices;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Create.AddOneCity;

public class AddOne(WorldWideDbContext context, MainContainer container) : IAddOne
{
    WorldWideDbContext Context { get; init; } = context;
    IContainer Conn { get; init; } = container.main(new ContainerBuilder());
    public async Task<bool> City(City city)
    {
        try
        {

            await Context.Cities.AddAsync(city);
            return await Context.SaveChangesAsync() > 0;
        }
        catch (Exception) { return false; }
    }
}