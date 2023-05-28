using Autofac;
using PaperStore.Services.Login;
using PaperStore.Services.Options;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Account.Login
{
    public class AccountLogin : IAccountLogin
    {
        readonly RegisterTypesContainer conn;
        public AccountLogin(RegisterTypesContainer _conn)
        {
            conn = _conn;
        }

        public bool SetLogIn(LoginModel model)
        {
            if (GetLogin(model))
                return false;

            return GetPassword(model) ? true : false;

        }
        public bool GetLogin(LoginModel model)
            =>
            conn.ResolveContainer(new()).Resolve<ILoginOptions>().LoginCheck(model).Result == 0 ? true : false; //Checking if email exists in db
        public bool GetPassword(LoginModel model)
            =>
            conn.ResolveContainer(new()).Resolve<IPasswordOptions>().PasswordDecrypt(model).Result; //Getting decrypted password

    }
}
