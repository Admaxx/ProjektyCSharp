using PaperStore.WareHouseData;

namespace PaperStore.Services.Login
{
    public interface IAccountLogin
    {
        bool GetLogin(LoginModel model);
        bool GetPassword(LoginModel model);
        bool SetLogIn(LoginModel model);
    }
}