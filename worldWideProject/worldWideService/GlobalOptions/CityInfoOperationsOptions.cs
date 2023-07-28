using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worldWideService.GlobalOptions;

public class CityInfoOperationsOptions
{
    public readonly static string CreateSuccessMessage = "Added successfully!";
    public readonly static string BadRequestMessage = "Incorrect data/internal error has occurred!";

    public readonly static string GetOneCityMess = "Attempting to get one city";
    public readonly static string AddOneCityMess = "Attempting to add one city";
    public readonly static string GetRandomCityMess = "Attempting to get random city";
    public readonly static string GetAllCitiesByRegionMess = "Attempting to get all cities by region";
}