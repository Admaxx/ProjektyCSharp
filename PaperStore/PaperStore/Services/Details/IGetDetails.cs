using PaperStore.WareHouseData;

namespace PaperStore.Services.Details
{
    public interface IGetDetails
    {
        Task<CurrentStock> Item(long Id);
    }
}
