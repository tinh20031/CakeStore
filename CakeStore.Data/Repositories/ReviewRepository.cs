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
    public class ReviewRepository : IReviewRepository
    {
        private readonly CakeStoreDbContext _context;
        public ReviewRepository(CakeStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddReview(Reviews review)
        {
            await _context.Reviews.AddAsync(review);

        }

        public void DeleteReview(Reviews review)
        {
           _context.Reviews.Remove(review);
        }

        public async Task<IEnumerable<Reviews>> GetListReviewByProductId(int ProductId )
        {
          return await _context.Reviews.Where(r => r.ProductId == ProductId).AsNoTracking().ToListAsync();
        }

        public async Task<Reviews> GetReviewById(int id)
        {
            return await _context.Reviews.AsNoTracking().FirstOrDefaultAsync(r => r.ReviewId == id);

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateReview(Reviews review)
        {
             _context.Reviews.Update(review);
        }
    }
}
