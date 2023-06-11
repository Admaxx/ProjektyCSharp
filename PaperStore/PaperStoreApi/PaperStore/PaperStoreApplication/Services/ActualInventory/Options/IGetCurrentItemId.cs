using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.Options
{
    internal interface IGetCurrentItemId
    {
        Task<long> ByAll(ModifyItemModel model);
    }
}