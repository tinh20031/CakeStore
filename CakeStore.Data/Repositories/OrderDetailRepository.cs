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
    public class OrderDetailRepository :IOrderDetailRepository
    {

        private readonly CakeStoreDbContext _context;

        public OrderDetailRepository(CakeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task AddOrderDetail (OrderDetails orderDetails)
        {
            await _context.OrderDetails.AddAsync(orderDetails);
        }
    }
}
