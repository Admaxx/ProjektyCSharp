using Autofac;

namespace PaperStore.Services.Options
{
    public class RegisterTypesContainer
    {
        public IContainer ResolveContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<CurrentWarehouse.MassRegistration>();
            builder.RegisterModule<Login.MassRegistration>();

            return builder.Build();
        }
    }
}
