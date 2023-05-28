using PaperStore.WareHouseData;

namespace PaperStore.Services.Login
{
    public interface IPasswordOptions
    {
        string PasswordEncrypt(LoginModel model);
        Task<bool> PasswordDecrypt(LoginModel model);
    }
}
