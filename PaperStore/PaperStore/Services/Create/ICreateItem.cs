using PaperStore.WareHouseData;

namespace PaperStore.Services.Create
{
    public interface ICreateItem
    {
        Task<string> Item(CurrentStock model);


    }
}
