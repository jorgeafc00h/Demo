using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogContext.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);

        Task<List<Product>> GetAllAsync();

        Task<Product> CreateAsync(Product model);

        Task<Product> InsertOrUpdateAsync(Product model);

        Task DeleteAsync(int id);
        Task<Product> GetProductAsync(int id);

        Task<int> CountAsync();

        IQueryable<Product> AsNotracking();
    }
}
