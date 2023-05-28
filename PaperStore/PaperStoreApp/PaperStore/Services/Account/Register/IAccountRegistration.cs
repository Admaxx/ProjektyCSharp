using PaperStore.WareHouseData;

namespace PaperStore.Services.Account.Register
{
    public interface IAccountRegistration
    {
        Task<bool> SetRegistration(LoginModel model);
        string SetPassword(LoginModel model);
        bool SetLogin(LoginModel model);
    }
}