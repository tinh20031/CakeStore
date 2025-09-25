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
    public class ProductRepository :IProductRepository
    {

        private readonly CakeStoreDbContext _context;

        public ProductRepository(CakeStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Products product)
        {
            await _context.Products.AddAsync(product);
        }

        public void  DeleteProduct(Products product)
        {
             _context.Products.Remove(product);
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
          return  await _context.Products.Include( t => t.Category).AsNoTracking().ToListAsync();
        }

        public async Task<Products> GetProductById(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateProduct(Products product)
        {
            _context.Products.Update(product);
        }
    }
}
