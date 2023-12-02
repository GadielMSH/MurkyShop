using Microsoft.EntityFrameworkCore;
using MurkyShop.Server.Data;
using MurkyShop.Server.Migrations;
using MurkyShop.Server.Repositories.Contracts;
using MurkyShop.Shared.Dtos;
using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ShoppingCartRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await this.applicationDbContext.CartItems.AnyAsync(c => c.CartID == cartId &&
                                                                        c.ProductID == productId);
        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if(await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in this.applicationDbContext.Peces
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartID = cartItemToAddDto.CartId,
                                      ProductID = product.Id,
                                      Qty = cartItemToAddDto.Qty,
                                  }).SingleOrDefaultAsync();
                if (item != null)
                {
                    var result = await this.applicationDbContext.CartItems.AddAsync(item);
                    await this.applicationDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await this.applicationDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                this.applicationDbContext.CartItems.Remove(item);
                await this.applicationDbContext.SaveChangesAsync();
            }

            return item;
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in this.applicationDbContext.Carts
                          join cartItem in this.applicationDbContext.CartItems
                          on cart.Id equals cartItem.CartID
                          where cartItem.Id == id
                          select new CartItem {
                              Id = cartItem.Id,
                              ProductID = cartItem.ProductID,
                              Qty = cartItem.Qty,
                              CartID = cartItem.CartID,
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in this.applicationDbContext.Carts
                          join cartItem in this.applicationDbContext.CartItems
                          on cart.Id equals cartItem.CartID
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductID = cartItem.ProductID,
                              Qty = cartItem.Qty,
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            var item = await this.applicationDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Qty = cartItemQtyUpdateDto.Qty;
                await this.applicationDbContext.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
