using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Options
{
    internal interface IModifyLastItem
    {
        Task<bool> ItemByModel(ModifyItemModel model, bool ModeChoose);
    }
}