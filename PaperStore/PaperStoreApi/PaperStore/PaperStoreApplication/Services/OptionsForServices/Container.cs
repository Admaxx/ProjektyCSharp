using Autofac;

namespace PaperStoreApplication.Services.OptionsForServices;

public class Container
{
    public IContainer RegistrationContainer(ContainerBuilder builder)
    {
        builder.RegisterModule<Account.Registration.RegistrationOptions.RegistrationUserRegistration>();
        builder.RegisterModule<Account.Login.LoginOptions.LoginUserRegistration>();


        builder.RegisterModule<OptionsForServices.Registration>();


        builder.RegisterModule<ActualInventory.Options.ShareRegistration>();
        builder.RegisterModule<ActualInventory.Create.CreateOptions.CreateRegistration>();
        builder.RegisterModule<ActualInventory.Update.UpdateOptions.UpdateRegistration>();
        builder.RegisterModule<ActualInventory.Delete.DeleteOptions.DeleteRegistration>();


        builder.RegisterModule<LastItem.Read.ReadOptions.RegistrationLast>();
        builder.RegisterModule<LastItem.Create.CreateOptions.CreateRegistration>();
        builder.RegisterModule<LastItem.Update.UpdateOptions.UpdateRegistration>();
        builder.RegisterModule<LastItem.Delete.DeleteOptions.DeleteRegistration>();
        builder.RegisterModule<LastItem.Options.LastItemOptionsRegistration>();

        return builder.Build();
    }
}