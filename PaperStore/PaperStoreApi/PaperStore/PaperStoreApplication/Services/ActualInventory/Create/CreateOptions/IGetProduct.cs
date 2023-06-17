namespace PaperStoreApplication.Services.ActualInventory.Create.CreateOptions;

public interface IGetProduct
{
    Task<long> ByNameAndCompany(string ProductName, string CompanyName);
}
