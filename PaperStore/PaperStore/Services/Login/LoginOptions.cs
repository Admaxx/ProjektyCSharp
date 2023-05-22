using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Login
{
    public class LoginOptions : ILoginOptions
    {
        PaperWarehouseContext context;
        public LoginOptions(PaperWarehouseContext _context)
        {
            context = _context;
        }

        public async Task<int> LoginCheck(LoginModel model)
            => await
            context.LoginOptions.Where(item => item.Email == model.Email).CountAsync();
        
    }
}