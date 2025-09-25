using CakeStore.Data.Entities;
using CakeStore.Data.Interfaces;
using CakeStoreAPI.Data;
using CakeStoreAPI.Migrations;
using CakeStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CakeStore.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CakeStoreDbContext _context;



        public CartRepository(CakeStoreDbContext context)
        {
            _context = context;

        }
        public async Task<Cart> GetCartByUserId(int userId )
        {
          return await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

        }
        public async Task<Cart> GetCartById(int id)
        {
            return await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.CartId == id);
        }

        public async Task<Cart> AddToCart(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }

            var existingCart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(c => c.UserId == cart.UserId);

            if (existingCart == null)
            {
                await _context.Carts.AddAsync(cart);
            }
            else
            {
                foreach (var item in cart.CartItems)
                {
                    var existingItem = existingCart.CartItems
                        .FirstOrDefault(ci => ci.ProductId == item.ProductId);
                    if (existingItem != null)
                    {
                        existingCart.CartItems.Add(item);


                    }
                    else
                    {
                        existingCart.CartItems.Add(item);
                    }
                }
                cart = existingCart;
            }

            await _context.SaveChangesAsync();

            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.CartId == cart.CartId);
        }


        public void UpdateCart(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            _context.Carts.Update(cart);
        }

        public void DeleteCart(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            _context.Carts.Remove(cart);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

      
    }
}
