using PaperStore.WareHouseData;

namespace PaperStore.Services.Delete
{
    public interface IRemoveItem
    {
        Task<string> Item(long Id);
    }
}
