using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Create
{
    public class ChooseCompany : IChooseCompany
    {
        PaperWarehouseContext context;

        public ChooseCompany(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<List<CompaniesList>> Company()
            => await
            context.CompaniesLists.Where(item => item.IsArchive == false)
                .ToListAsync();

    }
}
