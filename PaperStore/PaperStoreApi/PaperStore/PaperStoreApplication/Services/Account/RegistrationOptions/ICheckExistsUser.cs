using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.Account.RegistrationOptions
{
    internal interface ICheckExistsUser
    {
        Task<bool> CheckIfUsersExists(PaperWarehouseContext _context, string Email);
    }
}