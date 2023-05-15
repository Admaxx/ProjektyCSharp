using PaperStore.WareHouseData;

namespace PaperStore.Services.Update.Single
{
    public interface IUpdateItem
    {
        Task<string> Item(CurrentStock model);
    }
}
