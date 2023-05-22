using PaperStore.WareHouseData;

namespace PaperStore.Services.Login
{
    public interface IAccountRegistration
    {
        Task<bool> SetRegistration(LoginModel model);
        string SetPassword(LoginModel model);
        bool SetLogin(LoginModel model);
    }
}