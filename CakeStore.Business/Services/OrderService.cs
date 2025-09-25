using CakeStore.Business.DTO.Order;
using CakeStore.Business.DTO.Product;
using CakeStore.Business.Interfaces;
using CakeStore.Data.Entities;
using CakeStore.Data.Interfaces;
using CakeStoreAPI.Models;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, ICartItemRepository cartItemRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<IEnumerable<PreviewCartDto>> PreviewOrder(int[] CartItemId, int UserId  )
        {
            var cart = await _cartRepository.GetCartByUserId(UserId);
            if (cart == null)
            {
                throw new ArgumentException("Cart not found for the user");
            }
            var cartItemIds = _cartItemRepository.GetCartItemsByIds(CartItemId);
            if(cartItemIds is null)
            {
                throw new ArgumentException("invalid cartItem");
            }
          
            

            var orders = await _orderRepository.PreviewOrder();
            return orders.Select(o => new PreviewCartDto
            {
                CartItemId = o.CartItemId,
                ProductId = o.ProductId,
                ProductName = o.Product.Name,
                Image = o.Product.ImageUrl,
                Price = o.Product.Price,
                Quantity = o.Quantity,
                TotalPrice = o.Product.Price * o.Quantity

            }).ToList();
        }


        public async Task<string> CreateOrder ( RequestOrderDto dto, int userId)
        {
            //check user 
            var cart = await _cartRepository.GetCartByUserId(userId);
            if (cart == null)
            {
                throw new ArgumentException("Cart not found for the user");
            }
            var cartitem = await _cartItemRepository.GetCartItemsByIds(dto.CartItemIds);
          
           foreach(var item in cartitem)
            {
                if(item.Product is null)
                {
                    throw new Exception($"product not found in cartItemId({item.CartItemId})");
                }
                if (item.Quantity > item.Product.StockQuantity)
                {
                    throw new Exception("quantity is not available ");
                }
                if (!item.Product.Available)
                {
                    throw new Exception("product is not available ");
                }
            }

            var totalamount = cartitem.Sum(item => item.Quantity * item.Product.Price);
            var addOrder = new Orders
            {
                Address = dto.Address,
                Note = dto.note,
                PickupDate = dto.PickupDate,
                TotalAmount = totalamount,
                Status = status.Pending,
                UserId = userId,
                 OrderDetails = new List<OrderDetails>()

            };
           

            
            foreach (var item in cartitem)
            {
                addOrder.OrderDetails.Add(new OrderDetails
                {

                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price,


                });
                item.Product.StockQuantity -= item.Quantity;
                if (item.Product.StockQuantity <= 0)
                    item.Product.Available = false;

             
                _cartItemRepository.DeleteCartItem(item);

            }
           

            await _orderRepository.AddOrder(addOrder);
            await _orderRepository.SaveChangesAsync();
        
            return ("you have order successfully");

        }


        public async Task<IEnumerable<ResponOrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return orders.Select(o => new ResponOrderDto
            {
                OrderId = o.OrderId,
                Address = o.Address,
                Note = o.Note,
                PickupDate = o.PickupDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                OrderDate = o.OrderDate,
                Products = o.OrderDetails.Select(od => new ProductOfOrderDto
                {
                    ProductId = od.ProductId,
                    Name = od.Product.Name,
                    Price = od.Price,
                    Quantity = od.Quantity,
                    Image = od.Product.ImageUrl
                }).ToList()
            }).ToList();
        }

    }
}
