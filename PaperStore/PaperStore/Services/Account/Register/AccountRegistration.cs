using Autofac;
using PaperStore.Services.Login;
using PaperStore.Services.Options;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Account.Register
{
    public class AccountRegistration : IAccountRegistration
    {
        readonly PaperWarehouseContext context;
        readonly RegisterTypesContainer conn;
        public AccountRegistration(PaperWarehouseContext _context, RegisterTypesContainer _conn)
        {
            context = _context;
            conn = _conn;
        }

        public async Task<bool> SetRegistration(LoginModel model)
        {
            if (!SetLogin(model))
                return false;

            model.Password = SetPassword(model);

            await context.AddAsync(model);
            return await context.SaveChangesAsync() > 0 ? true : false;
        }
        public bool SetLogin(LoginModel model)
            =>
            conn.ResolveContainer(new()).Resolve<ILoginOptions>().LoginCheck(model).Result == 0 ? true : false; //Checking if email exists in db
        
        public string SetPassword(LoginModel model)
            => 
            conn.ResolveContainer(new()).Resolve<IPasswordOptions>().PasswordEncrypt(model) ?? string.Empty; //Getting Encrypted password
        

    }
}
