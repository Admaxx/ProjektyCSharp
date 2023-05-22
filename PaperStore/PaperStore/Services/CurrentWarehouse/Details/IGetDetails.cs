using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Details
{
    public interface IGetDetails
    {
        Task<CurrentStock> Item(long Id);
    }
}
