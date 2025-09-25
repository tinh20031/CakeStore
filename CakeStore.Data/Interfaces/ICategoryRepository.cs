using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int id);
        Task AddCategory(Category category);
        void UpdateCategory(Category Category);
        void DeleteCategory(Category Category);
        Task<bool> SaveChangesAsync();


    }
}
