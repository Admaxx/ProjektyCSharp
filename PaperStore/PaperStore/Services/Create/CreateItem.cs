using PaperStore.WareHouseData;

namespace PaperStore.Services.Create
{
    public class CreateItem : ICreateItem
    {
        PaperWarehouseContext context;
        public CreateItem(PaperWarehouseContext _context)
            =>
            context = _context;


        public async Task<string> Item(CurrentStock model)
        {
            await context.AddAsync(model);

            return await context.SaveChangesAsync() > 0
                ? "Dodano poprawie" : string.Empty;
        }


    }
}
