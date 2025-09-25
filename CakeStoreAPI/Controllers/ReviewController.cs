using CakeStore.Business.DTO.Reviews;
using CakeStore.Business.Interfaces;
using CakeStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CakeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetListReviewByProductId(int ProductId)
        {
            var reviews = await _reviewService.GetListReviewByProductId(ProductId);
            return Ok(reviews);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReview([FromForm] CreateReviewDto dto, IFormFile image )
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var addreview = await _reviewService.AddReview(dto, image, UserId);


                return Ok(addreview);
            }
            else
            {
                return BadRequest("Access denied ");
            }
          
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromForm] UpdateReviewDto dto, IFormFile image)
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var reviewid = await _reviewService.GetReviewById(id);
                var test = reviewid.UserId == UserId;
                if (reviewid == null)
                {
                    return NotFound();
                }
                if (reviewid.UserId != UserId)
                {
                    return BadRequest(new { message = "You do not have permission to edit this review." });
                }
                var result = await _reviewService.UpdateReview(id, dto, image);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            else
            {
                return Unauthorized("Access denied ");
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            if (User.IsInRole("Customer") )
            {
              
               
                var result = await _reviewService.DeleteReview(id);
             
                return Ok();
            }
            else
            {
                return Unauthorized("Access denied ");
            }
        }
    }
}
