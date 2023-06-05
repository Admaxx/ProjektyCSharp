using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.Account.LoginOptions;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.Account.Login
{
    public class LoginUser(PaperWarehouseContext conn, Container _container) : ILoginUser
    {
        PaperWarehouseContext _context = conn ?? throw new ArgumentNullException();
        IContainer _conn = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));

        public async Task<string> UserLogin(LoginOption model)
        {
            CreatingUsersToken token = new CreatingUsersToken();

            if (_conn.Resolve<IVerifyUsersPassword>().VerifyPassword(_context, model))
                return token.CreateToken(new UserCredentialsModel() { Email = model.Email });


            return string.Empty;
        }


    }
}
