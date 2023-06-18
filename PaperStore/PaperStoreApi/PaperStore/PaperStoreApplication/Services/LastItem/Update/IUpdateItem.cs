using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Update;

public interface IUpdateItem
{
    Task<bool> UpdateQtyAndRemainingItems(ModifyItemModel model, bool AddQtyToExists);
}
