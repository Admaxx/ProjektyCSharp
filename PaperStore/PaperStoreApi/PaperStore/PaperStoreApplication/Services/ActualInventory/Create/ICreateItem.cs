using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.Create;
public interface ICreateItem
{
    Task<bool> CreateItemByName(ModifyItemModel model);
}
