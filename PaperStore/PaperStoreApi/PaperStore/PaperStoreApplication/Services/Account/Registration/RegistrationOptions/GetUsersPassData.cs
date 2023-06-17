namespace PaperStoreApplication.Services.Account.Registration.RegistrationOptions
{
    internal class GetUsersPassData : IGetUsersPassData
    {
        public string GetEmail(string Email)
            =>
            Email;

        public string GetPassword(string Password)
            =>
            BCrypt.Net.BCrypt.HashPassword(Password);
    }
}
