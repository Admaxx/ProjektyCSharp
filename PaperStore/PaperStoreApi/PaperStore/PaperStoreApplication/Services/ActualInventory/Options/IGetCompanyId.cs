namespace PaperStoreApplication.Services.ActualInventory.Options
{
    internal interface IGetCompanyId
    {
        Task<long?> ByName(string CompanyName);
    }
}