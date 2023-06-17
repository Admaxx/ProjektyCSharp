using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.Account.Registration.RegistrationOptions
{
    internal interface ICheckExistsUser
    {
        Task<bool> CheckIfUsersExists(PaperWarehouseContext _context, string Email);
    }
}