using CakeStore.Business.DTO.Categorry;
using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategory();
        Task<CategoryDto> GetCategoryById(int id);
        Task<CategoryDto> AddCategory(CreateCategoryDto category);
        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category);
        Task<bool> DeleteCategoryAsync(int id);

    }
}