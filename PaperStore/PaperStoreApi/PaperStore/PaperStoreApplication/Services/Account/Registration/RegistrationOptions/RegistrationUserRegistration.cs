using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.Account.Registration;
using PaperStoreApplication.Services.OptionsForServices;

namespace PaperStoreApplication.Services.Account.Registration.RegistrationOptions
{
    public class RegistrationUserRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetUsersPassData>().As<IGetUsersPassData>();
            builder.RegisterType<CheckExistsUser>().As<ICheckExistsUser>();
            builder.RegisterType<RegistrationUser>().As<IRegistrationUser>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
        }
    }
}
