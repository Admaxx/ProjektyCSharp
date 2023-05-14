using PaperStore.WareHouseData;

namespace PaperStore.Services.Update
{
    public interface IChooseUpdateItemContext
    {

        Task<List<StockAdditionalInfo>> ChooseUpdateItems();
    }
}
