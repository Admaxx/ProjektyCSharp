using PaperStore.WareHouseData;

namespace PaperStore.Services.Update
{
    public interface IGetUpdatedItem
    {
        Task<CurrentStock> Item(long Id);
    }
}
