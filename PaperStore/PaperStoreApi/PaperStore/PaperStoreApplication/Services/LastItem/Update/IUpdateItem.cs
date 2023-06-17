using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Update;

public interface IUpdateItem
{
    Task<bool> UpdateItemByName(long Id, ModifyItemModel model, bool AddQtyToExists);
}
