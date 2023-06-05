using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.Account.Login;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.Account.LoginOptions
{
    public class LoginUserRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VerifyUsersPassword>().As<IVerifyUsersPassword>();
            builder.RegisterType<CreatingUsersToken>().As<ICreatingUsersToken>().WithParameter("userData", new UserCredentialsModel());
            builder.RegisterType<LoginUser>().As<ILoginUser>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
        }
    }
}
