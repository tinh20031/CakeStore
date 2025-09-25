using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeStoreAPI.Models;
namespace CakeStore.Data.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Reviews>> GetListReviewByProductId(int ProductId);
        Task<Reviews> GetReviewById(int id);
        Task AddReview(Reviews review);
        void UpdateReview(Reviews review);
        void DeleteReview(Reviews review);
        Task<bool> SaveChangesAsync();
    }
}
