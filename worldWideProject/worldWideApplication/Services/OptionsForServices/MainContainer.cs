using Autofac;

namespace worldWideApplication.Services.OptionsForServices;

public class MainContainer
{
    public IContainer main(ContainerBuilder builder)
    {
        builder.RegisterModule<CityInfoOperations.Read.GetAllCitiesFromOneRegion.Options.ClassRegister>();
        builder.RegisterModule<CityInfoOperations.Read.GetRandomCity.Options.ClassRegister>();
        builder.RegisterModule<CityInfoOperations.Read.GetOneCity.Options.ClassRegister>();

        builder.RegisterModule<CityInfoOperations.Create.AddOneCity.Options.ClassRegister>();

        return builder.Build();
    }
}
