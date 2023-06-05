using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.Account.RegistrationOptions;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.Account.Registration
{
    internal class RegistrationUser(PaperWarehouseContext conn, Container _container) : IRegistrationUser
    {
        readonly PaperWarehouseContext _context = conn ?? throw new ArgumentNullException(nameof(conn));
        readonly IContainer _conn = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));

        public async Task<bool> UserRegistration(LoginOption model)
        {
            if (!_conn.Resolve<ICheckExistsUser>().CheckIfUsersExists(_context, model.Email).Result)//If someone with that email is already in db
                return false;

            var UserRegistrationCredentials = _conn.Resolve<IGetUsersPassData>();
            
            await _context.LoginOptions.AddAsync(new LoginOption()
            {
                Email = UserRegistrationCredentials.GetEmail(model.Email),
                Password = UserRegistrationCredentials.GetPassword(model.Password)
                
            });

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
