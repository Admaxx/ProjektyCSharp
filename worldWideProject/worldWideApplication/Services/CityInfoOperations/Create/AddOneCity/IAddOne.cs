using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Create.AddOneCity;

public interface IAddOne
{
    Task<bool> City(City city);
}
