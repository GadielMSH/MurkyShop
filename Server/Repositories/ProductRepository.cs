using Microsoft.EntityFrameworkCore;
using MurkyShop.Server.Data;
using MurkyShop.Server.Migrations;
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

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await applicationDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await applicationDbContext.Products.FindAsync(id);
                return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.applicationDbContext.Products.ToListAsync();

            return products;
        }
    }
}
