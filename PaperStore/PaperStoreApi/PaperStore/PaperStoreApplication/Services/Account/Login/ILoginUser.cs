using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.Account.Login
{
    public interface ILoginUser
    {
        Task<string> UserLogin(LoginOption model);
    }
}