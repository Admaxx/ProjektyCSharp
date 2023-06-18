using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Create;
public interface ICreateItem
{
    Task<bool> AddQtyUpdateRemainingItems(ModifyItemModel model, bool ModeChoose);
}
