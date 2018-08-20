using Catalog.BusinessAccess;
using CatalogContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogContext.Repositories
{
    public class ProductRepository : GenericRepository<CatalogDbContext, Product>, IProductRepository
    {
        public ProductRepository(CatalogDbContext Context)
        {
            this.Context = Context;
        } 

        public Task<Product> GetProductAsync(int id)
        {
            return Context.Products
                //.Include(p=> p.NavitationTest)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> InsertOrUpdateAsync(Product model)
        {
            Context.Entry(model).State = model.Id == 0 ? EntityState.Added : EntityState.Modified;

            await Context.SaveChangesAsync();

            return model;
        }
    }
}
