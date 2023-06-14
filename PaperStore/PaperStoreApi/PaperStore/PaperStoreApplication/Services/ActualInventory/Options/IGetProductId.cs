namespace PaperStoreApplication.Services.ActualInventory.Options
{
    public interface IGetProductId
    {
        Task<long?> ByName(string ProductName, string CompanyName);
    }
}