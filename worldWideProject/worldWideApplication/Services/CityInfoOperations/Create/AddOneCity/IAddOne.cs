using worldWideDbModels;

namespace worldWideApplication.Services.CityInfoOperations.Create.AddOneCity;

public interface IAddOne
{
    Task<bool> Cities(City city);
}
