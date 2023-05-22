using Autofac;
using PaperStore.Services.Account.Login;
using PaperStore.Services.Account.Options;
using PaperStore.Services.Account.Register;
using PaperStore.Services.Options;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Login
{
    public class MassRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginOptions>().As<ILoginOptions>().WithParameter("_context", new PaperWarehouseContext());
            builder.RegisterType<PasswordOptions>().As<IPasswordOptions>().WithParameter("_context", new PaperWarehouseContext());

            builder.RegisterType<AccountRegistration>().As<IAccountRegistration>().WithParameter("_context", new PaperWarehouseContext()).WithParameter("_conn", new RegisterTypesContainer());
            builder.RegisterType<AccountLogin>().As<IAccountLogin>().WithParameter("_conn", new RegisterTypesContainer());
        }


    }
}
