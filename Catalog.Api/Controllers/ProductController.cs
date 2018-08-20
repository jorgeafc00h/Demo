using CatalogContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("api/Products")]
    public class ProductController :Controller
    {

        public ProductController(IProductRepository repo)
        {
            this.Repository = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await Repository.GetAllAsync();
        }

        // GET api/
        [HttpGet("{id}")]
        public async Task<Product> GetAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

        // POST api/
        [HttpPost]
        public async Task PostAsync(Product model)
        {
            await Repository.InsertOrUpdateAsync(model);
        }

        // PUT api/
        [HttpPut]
        public async Task PutAsync(Product model)
        {
            await Repository.InsertOrUpdateAsync(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
        }


        private IProductRepository Repository { get; set; }
    }
}
