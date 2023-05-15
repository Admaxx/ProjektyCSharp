using PaperStore.WareHouseData;

namespace PaperStore.Services.Update.Single
{
    public interface IGetUpdatedItem
    {
        Task<CurrentStock> Item(long Id);
    }
}
