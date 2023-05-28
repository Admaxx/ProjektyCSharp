using PaperStore.PaperStoreModel;
using PaperStore.Services.OptionsForServices;

namespace PaperStore.Services.ActualInventory.Create
{
    public interface ICreateItem
    {
        Task<bool> CreateItemByName(ModifyItemModel model);
    }
}