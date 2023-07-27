using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetOneCity.Options
{
    public class GetCityBy(WorldWideDbContext context) : IGetCityBy
    {
        WorldWideDbContext Conn = context;
        public async Task<City> GetOneCityByParams(CityDto city_dto)
            => await
            Conn.Cities
            .Where
            (item => item.Id == city_dto.Id
            && item.Country.Replace(" ","").ToLower() == (city_dto.Country ?? item.Country).Replace(" ", "").ToLower()
            && item.Population == (city_dto.Population ?? item.Population)
            && item.Name.Replace(" ", "").ToLower() == (city_dto.Name ?? item.Name).Replace(" ", "").ToLower()
            )
            .FirstAsync();

        

    }
}
