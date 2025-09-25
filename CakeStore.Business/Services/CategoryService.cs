
using CakeStore.Business.DTO.Categorry;
using CakeStore.Business.Interfaces;
using CakeStore.Data.Interfaces;
using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
          
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var categories = await _categoryRepository.GetAllCategory();
            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.Created_At,
             
            }).ToList();
        }
        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            return category == null ? null : new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.Created_At,
             
            };

        }
        public async Task<CategoryDto> AddCategory(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
             
            };
            category.Created_At = DateTimeOffset.UtcNow;
            category.Updated_At = DateTimeOffset.UtcNow;
            await _categoryRepository.AddCategory(category);
            await _categoryRepository.SaveChangesAsync();
            return category == null ? null : new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.Created_At,
             
            };

        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto dto)
        {
            var existing = await _categoryRepository.GetCategoryById(id);
            if (existing == null) return false;
            existing.Name = dto.Name;
                existing.Description = dto.Description;
            existing.Updated_At = DateTimeOffset.UtcNow;
            _categoryRepository.UpdateCategory(existing);
            var result = await _categoryRepository.SaveChangesAsync();
            return result;


        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var existing = await _categoryRepository.GetCategoryById(id);
            if (existing == null) return false;
            _categoryRepository.DeleteCategory(existing);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }
    }
}
