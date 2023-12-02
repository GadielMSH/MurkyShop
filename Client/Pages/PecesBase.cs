using Microsoft.AspNetCore.Components;
using MurkyShop.Client.Services.Contracts;
using MurkyShop.Shared.Dtos;
using MurkyShop.Shared.Models;

namespace MurkyShop.Client.Pages
{
    public class PecesBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();

            var shoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
            var totalQty = shoppingCartItems.Sum(i => i.Qty);

            ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);
        }
    }
}
