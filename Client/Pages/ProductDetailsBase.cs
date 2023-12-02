using Microsoft.AspNetCore.Components;
using MurkyShop.Client.Services;
using MurkyShop.Client.Services.Contracts;
using MurkyShop.Shared.Dtos;

namespace MurkyShop.Client.Pages
{
    public class ProductDetailsBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);

                //if (cartItemDto != null)
                //{
                //    ShoppingCartItems.Add(cartItemDto);
                //    await ManageCartItemsLocalStorageService.SaveCollection(ShoppingCartItems);
                //}

                NavigationManager.NavigateTo("/Carrito");
            }
            catch (Exception)
            {

                //Log Exception
            }
        }
    }
}
