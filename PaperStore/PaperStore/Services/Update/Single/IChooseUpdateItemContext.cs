using PaperStore.WareHouseData;

namespace PaperStore.Services.Update.Single
{
    public interface IChooseUpdateItemContext
    {

        Task<List<StockAdditionalInfo>> ChooseUpdateItems();
    }
}
