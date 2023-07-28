using worldWideApplication.Services.CityInfoOperations.Create.AddOneCity;
using worldWideModels.contexts;

namespace worldWideServiceMSTests;

[TestClass]
public class Adding_Data_To_DB_TEST
{
    [TestMethod]
    public void TestMethod1()
    {
        using (WorldWideDbContext context = new WorldWideDbContext())//First attemt of this test, will fix it maybe tomorrow...
        {
            using (context.Database.BeginTransaction())
            {
                AddOne city = new AddOne(new WorldWideDbContext());
                var newCity = city.City(new worldWideDbModels.City() { Name = "Bialystok", Country = "Poland", Population = 43523 });

                context.Add(newCity);



                context.Database.RollbackTransaction();

            }
        }
    }
}
