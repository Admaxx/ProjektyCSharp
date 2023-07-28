using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCountries;

public class GetAllCountries(WorldWideDbContext context) : IGetAllCountries
{
    WorldWideDbContext context { get; init; } = context;
    public async Task<List<string>> AllCountriesByRegion(Region region)
        => await
        context.Regions.Where
        (
            item => item.Name.Replace(" ", "").ToLower()
            == region.Name.Replace(" ", "").ToLower()
            &&
            item.Country.Replace(" ", "").ToLower()
            == (region.Country ?? item.Country).Replace(" ", "").ToLower()
        )
        .Select(item => item.Country).ToListAsync();
}
