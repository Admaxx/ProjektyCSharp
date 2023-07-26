using Autofac;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity.Options
{
    public class ClassRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetOne>().As<IGetOne>().WithParameter("context", new WorldWideDbContext());
        }
    }

}
