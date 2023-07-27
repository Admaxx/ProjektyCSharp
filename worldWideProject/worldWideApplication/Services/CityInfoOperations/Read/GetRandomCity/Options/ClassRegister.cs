using Autofac;
using worldWideApplication.Services.OptionsForServices;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetRandomCity.Options
{
    public class ClassRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetRandom>().As<IGetRandom>()
                .WithParameter("context", new WorldWideDbContext())
                .WithParameter("container", new MainContainer());
        }
    }

}
