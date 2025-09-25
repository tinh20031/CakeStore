using CakeStore.Business.DTO.Order;
using CakeStore.Business.Interfaces;
using CakeStore.Business.Services;
using CakeStore.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Authorize]
        [HttpGet("preview")]
        public async Task<IActionResult> PreviewOrder([FromQuery] int[] cartItemId)
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                var preview = await _orderService.PreviewOrder(cartItemId, UserId);
                return Ok(preview);
            }
            else
            {
                return BadRequest("Access denied ");
            }
        }

        [Authorize]
        [HttpPost("create_order")]
        public async Task<string> CreatOrder (RequestOrderDto dto)
        {
            if (User.IsInRole("Customer"))
            {
                var UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                var preview = await _orderService.CreateOrder(dto, UserId);
                return ("you create order successfully");
            }
            else
            {
                return ("Access denied ");
            }
        }


        [Authorize]
        [HttpGet("get_all_orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            if (User.IsInRole("Customer"))
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            else
            {
                return BadRequest("Access denied ");
            }
        }

    }
}
