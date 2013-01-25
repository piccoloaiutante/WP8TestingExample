using System.Collections.Generic;
using System.Threading.Tasks;
using OrangeCode.WpReborn.SQLiteApp.Db;
using OrangeCode.Wpreborn.SQLIteApp.Db.Model;

namespace OrangeCode.Wpreborn.SQLIteApp.Services
{
    public interface IDbServiceAsync
    {
        Task<IList<Product>> LoadProductsAsync();
    }

    public class DbServiceAsync :IDbServiceAsync
    {
        private readonly SQLiteAsyncConnection _context;

        public DbServiceAsync(SQLiteAsyncConnection context)
        {
            _context = context;
        }

        public async Task<IList<Product>> LoadProductsAsync()
        {
            return await _context.Table<Product>().ToListAsync();
        }
    }
}
