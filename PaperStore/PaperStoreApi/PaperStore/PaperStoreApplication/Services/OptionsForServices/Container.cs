using Autofac;

namespace PaperStoreApplication.Services.OptionsForServices;

public class Container
{
    public IContainer RegistrationContainer(ContainerBuilder builder)
    {
        builder.RegisterModule<OptionsForServices.Registration>();
        builder.RegisterModule<ActualInventory.UpdateOptions.DeleteRegistration>();
        builder.RegisterModule<ActualInventory.Options.ShareRegistration>();

        builder.RegisterModule<ActualInventory.CreateOptions.CreateRegistration>();
        builder.RegisterModule<ActualInventory.DeleteOptions.DeleteRegistration>();

        return builder.Build();
    }
}

