using PaperStoreApplication.Contexts;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.Account.Login.LoginOptions
{
    internal interface IVerifyUsersPassword
    {
        bool VerifyPassword(PaperWarehouseContext conn, LoginOption model);
    }
}