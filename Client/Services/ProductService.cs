using MurkyShop.Client.Services.Contracts;
using MurkyShop.Shared.Dtos;
using MurkyShop.Shared.Models;
using System.Net.Http.Json;

namespace MurkyShop.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var product = await this.httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Products");

                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
