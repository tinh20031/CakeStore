using CakeStore.Business.DTO.Categorry;
using CakeStore.Business.DTO.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> AddProduct(CreateProductDto product, IFormFile Image);
        Task<bool> UpdateProductAsync(int id, UpdateProductDto product, IFormFile Image);
        Task<bool> DeleteProductAsync(int id);
    }
}
