namespace PaperStore.Services.ActualInventory.CreateOptions
{
    public interface IGetAdditionalInfo
    {
        Task<long> ByName(string AdditionalInfoName);
    }
}