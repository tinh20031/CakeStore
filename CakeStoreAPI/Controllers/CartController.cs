using CakeStore.Business.DTO.Cart;
using CakeStore.Business.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCartByUserId()
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                var cart = await _cartService.GetCartByUserId(UserId);
                return Ok(cart);
            }
            else
            {
                return BadRequest("Access denied ");
            }
        }

        [Authorize]
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(AddToCartDto dto)
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                var cart = await _cartService.AddToCart(UserId, dto);
                return Ok(cart);
            }
            else
            {
                return BadRequest("Access denied ");
            }
        }

        [Authorize]
        [HttpPut("putQuantity")]
        public async Task<IActionResult> PutQuantity(PutCartQuantityDto dto)
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                var cart = await _cartService.PutCartQuantity(UserId, dto);
                return Ok(cart);
            }
            else
            {
                return BadRequest("Access denied ");
            }
        }


        [Authorize]
        [HttpDelete("delete_cartItem")]
        public async Task<string> DeleteCartItem(int CartItem)
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                var cart = await _cartService.DeleteCartItem(UserId, CartItem);
                return ("your cart item has been deleted");
            }
            else
            {
                return ("Access denied ");
            }
        }



        [Authorize]
        [HttpDelete("delete_cart")]
        public async Task<string> DeleteCart()
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                var cart = await _cartService.DeleteCart(UserId);
                return ("your cart has been deleted");
            }
            else
            {
                return ("Access denied ");
            }
        }




    }
}
