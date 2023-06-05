using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PaperStoreApplication.Contexts;

namespace PaperStoreTests.TestCreate.IntegrationTests
{
    [TestClass]
    public class CreateNewItemTest
    {
        int randomQty = 0;
        int randomProductName = 0;


        [TestMethod]
        public void shouldNotAddNoIdSpecify()
        {
            using (var context = new PaperWarehouseContext())
            {
                using (var createTransation = new PaperWarehouseContext().Database.BeginTransactionAsync())
                {
                    context.CurrentStocks.Add(new PaperStoreModel.Models.CurrentStock() { Qty = randomQty, ProductName = randomProductName });

                    Assert.ThrowsException<DbUpdateException>(() => context.SaveChanges());

                    createTransation.Result.Rollback();
                }
            }

        }



    }
}
