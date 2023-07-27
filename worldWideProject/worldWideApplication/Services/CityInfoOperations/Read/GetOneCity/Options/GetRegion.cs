using Microsoft.EntityFrameworkCore;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity.Options
{
    public class GetRegion(WorldWideDbContext context) : IGetRegion
    {
        WorldWideDbContext Conn = context;
        public string RegionByString(string Country)
            => 
            Conn.Regions.
            FirstAsync(item => item.Country.Replace(" ", string.Empty).ToLower() == Country.Replace(" ", string.Empty).ToLower()).Result.Name;



    }
}
