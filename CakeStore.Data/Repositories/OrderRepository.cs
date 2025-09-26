using CakeStore.Data.Entities;
using CakeStore.Data.Interfaces;
using CakeStoreAPI.Data;
using CakeStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CakeStoreDbContext _context;

        public OrderRepository(CakeStoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CartItem>> PreviewOrder()
        {
            var preview=  _context.CartItems.Include(p => p.Product).ToListAsync();
            return await preview;
        }

        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _context.Orders.Include(o => o.OrderDetails).ThenInclude(p => p.Product).ToListAsync();
        }
        public async Task AddOrder(Orders orders)
        {
             await _context.Orders.AddAsync(orders);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Orders> GetOrderById(int id)
        {
            return await _context.Orders.Include(o => o.OrderDetails).ThenInclude(p => p.Product).FirstOrDefaultAsync(o => o.OrderId == id);
        }
    }
}
