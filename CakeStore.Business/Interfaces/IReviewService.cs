using CakeStore.Business.DTO.Reviews;
using CakeStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetListReviewByProductId(int ProductId);
        Task<ReviewDto> GetReviewById(int id);
        Task <ReviewDto>  AddReview(CreateReviewDto dto, IFormFile image, int UserId);
        Task<bool> UpdateReview(int id, UpdateReviewDto dto, IFormFile image);
        Task<bool> DeleteReview(int id);

    }
}
