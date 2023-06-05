using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.Account.Registration
{
    public interface IRegistrationUser
    {
        Task<bool> UserRegistration(LoginOption model);
    }
}