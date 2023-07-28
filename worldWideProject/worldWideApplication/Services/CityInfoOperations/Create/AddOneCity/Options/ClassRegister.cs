using Autofac;
using worldWideApplication.Services.OptionsForServices;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Create.AddOneCity.Options;

public class ClassRegister : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AddOne>().As<IAddOne>()
            .WithParameter("context", new WorldWideDbContext())
            .WithParameter("container", new MainContainer());
    }
}