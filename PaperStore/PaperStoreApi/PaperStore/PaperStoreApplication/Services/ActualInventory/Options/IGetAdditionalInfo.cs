namespace PaperStoreApplication.Services.ActualInventory.Options;
public interface IGetAdditionalInfo
{
    Task<long?> ByName(string AdditionalInfoName);
}
