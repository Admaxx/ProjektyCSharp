using PaperStore.WareHouseData;

namespace PaperStore.Services.Update
{
    public interface IUpdateItem
    {
        Task<string> Item(CurrentStock model);
    }
}
