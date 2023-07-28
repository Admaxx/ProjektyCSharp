using Autofac;
using worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCities;
using worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCountries;
using worldWideApplication.Services.OptionsForServices;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options;

public class ClassRegister : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetAll>().As<IGetAll>().WithParameter("container", new MainContainer());
        builder.RegisterType<GetAllCountries>().As<IGetAllCountries>().WithParameter("context", new WorldWideDbContext());
        builder.RegisterType<GetAllCities>().As<IGetAllCities>().WithParameter("context", new WorldWideDbContext());
    }
}

