using PaperStore.PaperStoreModel;

namespace PaperStore.Services.OptionsForServices
{
    public interface IReadAllItems
    {
        List<CurrentStock> GetAllItems(bool? IsArchive);
    }
}