using Autofac;

namespace PaperStore.Services.OptionsForServices
{
    public class Container
    {
        public IContainer RegistrationContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<OptionsForServices.Registration>();

            builder.RegisterModule<ActualInventory.CreateOptions.CreateRegistration>();

            return builder.Build();
        }
    }
}
