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
    public class CategoryRepository : ICategoryRepository
    {

        private readonly CakeStoreDbContext _context;
        public CategoryRepository(CakeStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
           await _context.Categories.AddAsync(category);
        }

        public void DeleteCategory(Category Category)
        {
            _context.Categories.Remove(Category);
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
           return   await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
          return  await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
          return  await _context.SaveChangesAsync() > 0;
        }

        public void  UpdateCategory(Category Category)
        {
             _context.Categories.Update(Category);
        }
    }
}
