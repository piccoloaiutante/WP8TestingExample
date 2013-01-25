using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeCode.WpReborn.SQLiteApp.Db;
using OrangeCode.Wpreborn.SQLIteApp.Db.Model;

namespace OrangeCode.Wpreborn.SQLIteApp.Services
{
    public interface IDbService
    {
        Task<IList<Product>> LoadProductsAsync();
        IList<Product> LoadProducts();
    }

    public class DbService :IDbService
    {
        private readonly SQLiteAsyncConnection _context;

        public DbService(SQLiteAsyncConnection context)
        {
            _context = context;
        }


        public async Task<IList<Product>> LoadProductsAsync()
        {
            return await _context.Table<Product>().ToListAsync();
        }

        public  IList<Product> LoadProducts()
        {
            return new List<Product>();
        }
    }
}
