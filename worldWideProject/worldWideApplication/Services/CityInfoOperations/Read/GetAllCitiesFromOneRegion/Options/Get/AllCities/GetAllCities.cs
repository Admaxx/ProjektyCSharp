using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCountries;
using worldWideApplication.Services.OptionsForServices;
using worldWideDbModels;
using worldWideModels.contexts;

namespace worldWideApplication.Services.CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.Get.AllCities
{
    public class GetAllCities(WorldWideDbContext context) : IGetAllCities
    {
        WorldWideDbContext context { get; init; } = context;
        public List<City> AllCitiesByCountries(List<string> countries)
            =>
            context.Cities.Where(item => countries.Any(items => items == item.Country)).ToList();



    }

}
