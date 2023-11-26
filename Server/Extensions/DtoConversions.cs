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
    }
}
