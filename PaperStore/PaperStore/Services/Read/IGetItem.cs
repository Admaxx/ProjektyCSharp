using PaperStore.WareHouseData;

namespace PaperStore.Services.Read
{
    public interface IGetItem
    {
        Task<List<CurrentStock>> Item(string Name);
    }
}
