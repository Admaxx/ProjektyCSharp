using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Read
{
    public interface IGetItem
    {
        Task<List<CurrentStock>> Item(string Name);
    }
}
