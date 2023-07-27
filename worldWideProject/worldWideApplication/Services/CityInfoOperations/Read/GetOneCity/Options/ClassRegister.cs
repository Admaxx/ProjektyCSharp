using Autofac;
using worldWideApplication.Services.OptionsForServices;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity.Options
{
    public class ClassRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetOne>().As<IGetOne>().WithParameter("container", new MainContainer());
            builder.RegisterType<GetCityBy>().As<IGetCityBy>().WithParameter("context", new WorldWideDbContext());
            builder.RegisterType<GetRegion>().As<IGetRegion>().WithParameter("context", new WorldWideDbContext());
        }
    }

}
