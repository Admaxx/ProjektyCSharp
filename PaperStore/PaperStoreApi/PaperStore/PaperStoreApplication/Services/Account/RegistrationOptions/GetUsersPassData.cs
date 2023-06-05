namespace PaperStoreApplication.Services.Account.RegistrationOptions
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
