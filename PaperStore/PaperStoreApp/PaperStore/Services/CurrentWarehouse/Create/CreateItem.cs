using PaperStore.WareHouseData;
using LINQPad;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PaperStore.Services.CurrentWarehouse.Create
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
                    ? AllData.SuccessfullCreated : string.Empty;
        }


    }
}
