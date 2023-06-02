namespace PaperStore.Services.ActualInventory.CreateOptions;

public interface IGetProduct
{
    Task<long> ByNameAndCompany(string ProductName, string CompanyName);
}
