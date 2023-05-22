using Microsoft.EntityFrameworkCore;
using PaperStore.Services.Login;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Account.Options
{
    public class PasswordOptions : IPasswordOptions
    {
        PaperWarehouseContext context;
        public PasswordOptions(PaperWarehouseContext _context)
        {
            context = _context;
        }

        public string PasswordEncrypt(LoginModel model)
            =>
            BCrypt.Net.BCrypt.HashPassword(model.Password);

        public async Task<bool> PasswordDecrypt(LoginModel model)
        {
            var GettingPassword = await context.LoginOptions.Where(item => item.Email == model.Email).FirstAsync();
            return BCrypt.Net.BCrypt.Verify(model.Password, GettingPassword.Password) ? true : false;
        }
    }
}
