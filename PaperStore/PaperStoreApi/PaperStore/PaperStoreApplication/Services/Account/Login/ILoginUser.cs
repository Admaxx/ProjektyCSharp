using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.Account.Login
{
    public interface ILoginUser
    {
        string UserLogin(LoginOption model);
    }
}