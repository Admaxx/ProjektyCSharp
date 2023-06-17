using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Create;
public interface ICreateItem
{
    Task<bool> CreateItemByName(ModifyItemModel model);
}
