using System.IO;
using Microsoft.Phone.Testing;
using OrangeCode.WpReborn.SQLiteApp.Db;
using OrangeCode.Wpreborn.SQLIteApp.Db.Model;
using OrangeCode.Wpreborn.SQLIteApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace OrangeCode.WpReborn.SQLiteTestingApp.Services
{
    [TestClass]
    public class DbServiceFixture
    {
        private IDbServiceAsync _service;

        public DbServiceFixture()
        {
            var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "TestDb.sqlite");
            _service= new DbServiceAsync(new SQLiteAsyncConnection(dbPath));

            PrepareDb();
        }

        private void PrepareDb()
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "TestDb.sqlite"));

            connection.DropTableAsync<Product>();
            connection.CreateTableAsync<Product>();

            connection.InsertAsync(new Product { Name = "Product 1", Serial = "123456" });

        }
        
        [TestMethod]
        public async void LoadProductsAsync_Should_Load_Data_FromDb()
        {
            var data= await _service.LoadProductsAsync();

            Assert.AreEqual(data.Count,1);

        }
    }
}
