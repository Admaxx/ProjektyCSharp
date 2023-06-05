using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.Account.RegistrationOptions
{
    internal class CheckExistsUser : ICheckExistsUser
    {
        public async Task<bool> CheckIfUsersExists(PaperWarehouseContext _context, string Email)
            => await
            _context.LoginOptions.AsNoTracking().Where(item => item.Email.ToLower() == Email.ToLower()).AnyAsync() ? false : true;

    }
}
