
using CakeStore.Business.DTO.Product;
using CakeStore.Business.Interfaces;
using CakeStore.Data.Interfaces;
using CakeStore.Data.Repositories;
using CakeStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly ICloudinaryService _cloudinaryService;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICloudinaryService cloudinaryService, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
          
            _cloudinaryService = cloudinaryService;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var product = await _productRepository.GetAllProducts();
            return product.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Size = p.Size,
                Available = p.Available,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                ImageUrl =p.ImageUrl,
                StockQuantity = p.StockQuantity
            });
        }
        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return product == null ? null : new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Size = product.Size,
                Available = product.Available,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name,
                ImageUrl = product.ImageUrl,
                StockQuantity = product.StockQuantity
            };
        }
        public async Task<ProductDto> AddProduct (CreateProductDto dto, IFormFile Image)
        {
            var newproduct = new Products
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Size = dto.Size,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId,
               
            };
            var uploadimage = await _cloudinaryService.UploadImage(Image);
            newproduct.ImageUrl = uploadimage;


            newproduct.Created_At = DateTimeOffset.UtcNow;
            newproduct.Updated_At = DateTimeOffset.UtcNow;
            await _productRepository.AddProduct(newproduct);
            await _productRepository.SaveChangesAsync();
            return new ProductDto
            {
                ProductId = newproduct.ProductId,
                Name = newproduct.Name,
                Description = newproduct.Description,
                Price = newproduct.Price,
                Available = newproduct.Available,
                ImageUrl = newproduct.ImageUrl,
                CategoryName = newproduct.Category?.Name,
                Size = newproduct.Size,
                StockQuantity = newproduct.StockQuantity,
                CategoryId = newproduct.CategoryId,

            };

        }
        public async Task<bool> UpdateProductAsync (int id, UpdateProductDto dto, IFormFile Image)
        {
            var existing = await _productRepository.GetProductById(id);
            if (existing == null) return false;
           existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.Price = (decimal)dto.Price;
            existing.Size = dto.Size;
            existing.StockQuantity = (int)dto.StockQuantity;
            existing.Available = (bool)dto.Available;
                existing.CategoryId = (int)dto.CategoryId;   
      
            var uploadimage =  await _cloudinaryService.UploadImage(Image);
            existing.ImageUrl =  uploadimage;
            existing.Updated_At = DateTimeOffset.UtcNow;
       if (dto.CategoryId != null)
            {
                var category = _categoryRepository.GetCategoryById(dto.CategoryId.Value);
                if (category == null)
                {
                    throw new Exception("category k ton tai ");
                }
                existing.CategoryId = dto.CategoryId.Value;
            }
           
            _productRepository.UpdateProduct(existing);
            var result = await _productRepository.SaveChangesAsync();
            return result;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var existing = await _productRepository.GetProductById(id);
            if (existing == null) return false;
            _productRepository.DeleteProduct(existing);
            var result = await _productRepository.SaveChangesAsync();
            return result;
        }
    }
}
