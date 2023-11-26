using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Pez>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Pez> GetItem(int id);
        Task<ProductCategory> GetCategory(int id);

    }
}
