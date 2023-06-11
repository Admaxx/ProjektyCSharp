using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.Options
{
    public interface ICreateOrUpdate
    {
        bool ChooseItem(ModifyItemModel model);
    }
}