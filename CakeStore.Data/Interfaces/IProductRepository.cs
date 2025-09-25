using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductById(int id);
        Task AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(Products product);
        Task<bool> SaveChangesAsync();
    }
}
