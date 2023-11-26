using Microsoft.EntityFrameworkCore;
using MurkyShop.Server.Data;
using MurkyShop.Server.Repositories.Contracts;
using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.applicationDbContext.ProductCategories.ToListAsync();

            return categories;
        }

        public Task<ProductCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pez> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pez>> GetItems()
        {
            var pez = await this.applicationDbContext.Peces.ToListAsync();

            return pez;
        }
    }
}
