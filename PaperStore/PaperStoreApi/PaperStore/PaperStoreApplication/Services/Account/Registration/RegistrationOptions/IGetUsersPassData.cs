namespace PaperStoreApplication.Services.Account.Registration.RegistrationOptions
{
    public interface IGetUsersPassData
    {
        string GetEmail(string Email);
        string GetPassword(string Password);
    }
}
