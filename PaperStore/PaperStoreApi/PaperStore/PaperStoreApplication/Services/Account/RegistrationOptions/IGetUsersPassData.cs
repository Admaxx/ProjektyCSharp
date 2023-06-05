namespace PaperStoreApplication.Services.Account.RegistrationOptions
{
    public interface IGetUsersPassData
    {
        string GetEmail(string Email);
        string GetPassword(string Password);
    }
}
