using PaperStore.PaperStoreModel;

namespace PaperStore.Services.OptionsForServices
{
    public interface IReadAllItems
    {
        Task<List<CurrentStock>> GetAllItems(bool? IsArchive);
    }
}