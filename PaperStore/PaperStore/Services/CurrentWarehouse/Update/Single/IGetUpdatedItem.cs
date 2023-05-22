using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Update.Single
{
    public interface IGetUpdatedItem
    {
        Task<CurrentStock> Item(long Id);
    }
}
