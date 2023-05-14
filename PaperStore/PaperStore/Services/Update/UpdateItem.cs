using PaperStore.WareHouseData;

namespace PaperStore.Services.Update
{
    public class UpdateItem : IUpdateItem
    {
        PaperWarehouseContext context;

        public UpdateItem(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<string> Item(CurrentStock model)
        {
            model.UpdateData = DateTime.Now;

            await Task.Run(() =>
            {
                context.Update(model);
            });
            return await context.SaveChangesAsync() > 0
                ? "Zmieniono poprawnie" : string.Empty;
        }
    }
}
