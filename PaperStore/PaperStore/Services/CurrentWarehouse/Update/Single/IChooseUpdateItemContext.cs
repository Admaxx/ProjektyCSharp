using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Update.Single
{
    public interface IChooseUpdateItemContext
    {

        Task<List<StockAdditionalInfo>> ChooseUpdateItems();
    }
}
