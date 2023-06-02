namespace PaperStore.Services.ActualInventory.UpdateOptions;

public interface IGetModel
{
    Task<CurrentStock> ModelById(long Id);
}
