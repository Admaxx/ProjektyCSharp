using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.Update;

public interface IUpdateItem
{
    Task<bool> UpdateItemByName(long Id, ModifyItemModel model, bool AddQtyToExists);
}
