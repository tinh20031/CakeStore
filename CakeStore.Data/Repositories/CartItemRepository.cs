using CakeStore.Data.Entities;
using CakeStore.Data.Interfaces;
using CakeStoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly CakeStoreDbContext _context;
        public CartItemRepository(CakeStoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CartItem>> GetCartItemsByIds(int[] cartItemIds)
        {
            return await _context.CartItems.Include(p => p.Product).Include(c => c.Cart).Where(ci => cartItemIds.Contains(ci.CartItemId)).ToListAsync();
           
        }
        public void PutCartQuantity(CartItem cartItem)
        {
            if (cartItem is null)
            {
                throw new ArgumentNullException(nameof(cartItem));
            }
            _context.CartItems.Update(cartItem);
        }


        public void DeleteCartItem(CartItem cartItem)
        {
            if (cartItem == null)
            {
                throw new ArgumentNullException(nameof(cartItem));
            }
            _context.CartItems.Remove(cartItem);
        }
    }
}
