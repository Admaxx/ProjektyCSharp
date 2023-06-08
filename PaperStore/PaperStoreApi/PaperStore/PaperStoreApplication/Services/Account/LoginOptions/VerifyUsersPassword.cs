using Autofac;
using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.Account.LoginOptions
{
    internal class VerifyUsersPassword : IVerifyUsersPassword
    {
        public bool VerifyPassword(PaperWarehouseContext conn, LoginOption model)
            =>
            BCrypt.Net.BCrypt.Verify(model.Password, conn.LoginOptions
                .FirstAsync(item => item.Email.ToLower() == model.Email).Result.Password);


    }
}
