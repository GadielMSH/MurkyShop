using MurkyShop.Shared.Dtos;
using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Pez> peces,
                                            IEnumerable<ProductCategory> productCategories)
        {
            return (from pez in peces
                    join productCategory in productCategories
                    on pez.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = pez.Id,
                        Name = pez.Nombre,
                        Description = pez.Descripcion,
                        ImageUrl = pez.ImageURL,
                        Price = pez.Precio,
                        Qty = pez.Qty,
                        CategoryId = pez.CategoryId,
                        CategoryName = productCategory.Name
                    }).ToList();
        }

        public static ProductDto ConvertToDto(this Pez peces,
                                            ProductCategory productCategory)
        {
            return new ProductDto
            { 
                Id = peces.Id,
                Name =  peces.Nombre,
                Description = peces.Descripcion,
                ImageUrl = peces.ImageURL,
                Price = peces.Precio,
                Qty = peces.Qty,
                CategoryId = peces.CategoryId,
                CategoryName = productCategory.Name
            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
                                                            IEnumerable<Pez> peces)
        {
            return (from cartItem in cartItems
                    join product in peces
                    on cartItem.ProductID equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductID = cartItem.ProductID,
                        ProductName = product.Nombre,
                        ProductDescription = product.Descripcion,
                        ProductImageURL = product.ImageURL,
                        Price = product.Precio,
                        CartId = cartItem.CartID,
                        Qty = cartItem.Qty,
                        TotalPrice = product.Precio * cartItem.Qty
                    }).ToList();
        }

        public static CartItemDto ConvertToDto(this CartItem cartItem,
                                                            Pez product)
        {
            return new CartItemDto
                {
                    Id = cartItem.Id,
                    ProductID = cartItem.ProductID,
                    ProductName = product.Nombre,
                    ProductDescription = product.Descripcion,
                    ProductImageURL = product.ImageURL,
                    Price = product.Precio,
                    CartId = cartItem.CartID,
                    Qty = cartItem.Qty,
                    TotalPrice = product.Precio * cartItem.Qty
                };
        }
    }
}
