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

        public string UserLogin(LoginOption model)
        {
            try
            {
                if (_conn.Resolve<IVerifyUsersPassword>().VerifyPassword(_context, model))
                    return _conn.Resolve<ICreatingUsersToken>().CreateToken(new UserCredentialsModel() { Email = model.Email });
            }
            catch (Exception) { }
            return string.Empty;
        }
    }
}
