
using CakeStore.Business.DTO.Reviews;
using CakeStore.Business.Interfaces;
using CakeStore.Data.Interfaces;
using CakeStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
     
        private readonly ICloudinaryService _cloudinaryService;


        public ReviewService(IReviewRepository reviewRepository, ICloudinaryService cloudinaryService   )
        {
            _reviewRepository = reviewRepository;
        
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IEnumerable<ReviewDto>> GetListReviewByProductId(int productId)
        {
            var reviews = await _reviewRepository.GetListReviewByProductId(productId);

            return reviews
                .Where(r => r.ProductId == productId)
                .Select(r => new ReviewDto
                {
                    ReviewId = r.ReviewId,
                   Comment = r.Comment,
                    Rating = r.Rating,
                   PhotoUrl = r.PhotoUrl,
                   ProductId = productId,
                  UserId = r.UserId

                })
                .ToList();
        }


        public async Task<ReviewDto> AddReview(CreateReviewDto dto, IFormFile image, int UserId )
        {
           
            if (dto.Rating < 1 || dto.Rating > 5)
            {
                throw new ArgumentOutOfRangeException("Rating must be between 1 and 5");
            }
           string photoUrl = null;
            if (image != null)
            {
                photoUrl = await _cloudinaryService.UploadImage(image);
            }
            var newReview = new Reviews
            {
                ProductId = dto.ProductId,
                UserId = UserId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                PhotoUrl = photoUrl,
                ReviewDate = DateTimeOffset.UtcNow,
                Created_At = DateTimeOffset.UtcNow,
                Updated_At = DateTimeOffset.UtcNow
            };
            await _reviewRepository.AddReview(newReview);
            await _reviewRepository.SaveChangesAsync();
            return new ReviewDto
            {
                ReviewId = newReview.ReviewId,
                ProductId = newReview.ProductId,
                UserId = newReview.UserId,
                Rating = newReview.Rating,
                Comment = newReview.Comment,
                PhotoUrl = newReview.PhotoUrl
            };
        }

       public async Task<bool> UpdateReview ( int id , UpdateReviewDto dto, IFormFile image)
        {
            var existingReview = await _reviewRepository.GetReviewById(id);
            if (existingReview == null)
            {
                return false; 
            }
        
           if ( dto.Rating.HasValue)
            {
                if (dto.Rating < 1 || dto.Rating > 5)
                {
                    throw new ArgumentOutOfRangeException("Rating must be between 1 and 5");
                }
                existingReview.Rating = dto.Rating.Value;
            }
           if ( string.IsNullOrWhiteSpace(dto.Comment) == false)
            {
                existingReview.Comment = dto.Comment;
            }

            if (image != null)
            {
                var imagereview = await _cloudinaryService.UploadImage(image);
                existingReview.PhotoUrl = imagereview;
            }
       
           
            existingReview.Updated_At = DateTimeOffset.UtcNow;
            _reviewRepository.UpdateReview(existingReview);
            await _reviewRepository.SaveChangesAsync();
            return true; 

        }

        public async Task<bool> DeleteReview(int id)
        {
            var existingReview = await _reviewRepository.GetReviewById(id);
            if (existingReview == null)
            {
                return false; 
            }
            _reviewRepository.DeleteReview(existingReview);
            await _reviewRepository.SaveChangesAsync();
            return true; 
        }

        public async Task<ReviewDto> GetReviewById(int id)
        {
            var review = await _reviewRepository.GetReviewById(id);
            return review == null ? null : new ReviewDto
            {
                ReviewId = review.ReviewId,
                ProductId = review.ProductId,
                UserId = review.UserId,
                Rating = review.Rating,
                Comment = review.Comment,
                PhotoUrl = review.PhotoUrl
            };
        }
    }
}
