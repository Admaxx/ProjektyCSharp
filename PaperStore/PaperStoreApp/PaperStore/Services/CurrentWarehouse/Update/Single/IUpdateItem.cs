using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Update.Single
{
    public interface IUpdateItem
    {
        Task<string> Item(CurrentStock model);
    }
}
