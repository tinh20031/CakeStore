
using CakeStore.Business.DTO.Cart;
using CakeStore.Business.Interfaces;
using CakeStore.Data.Entities;
using CakeStore.Data.Interfaces;
using CakeStoreAPI.Migrations;
using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CakeStore.Business.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ICartItemRepository _cartItemRepository;

        public CartService(ICartRepository cartRepository, IUserService userService, IProductService productService, ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _userService = userService;
            _productService = productService;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<CartDto> GetCartByUserId(int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var cart = await _cartRepository.GetCartByUserId(userId);
            if (cart == null) return null;
            var cartDto = new CartDto
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                Items = cart.CartItems.Select(ci => new CartItemDto
                {
                    CartItemId= ci.CartItemId,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    ProductName = ci.Product.Name,
                    Image = ci.Product.ImageUrl,
                    Price = ci.Product.Price


                }).ToList()
            };
            return cartDto;
        }
        public async Task<CartDto> AddToCart(int userId, AddToCartDto dto)
        {
            // Kiểm tra người dùng
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            // Kiểm tra sản phẩm
            var product = await _productService.GetProductById(dto.ProductId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            // Kiểm tra số lượng
            if (dto.Quantity <= 0 || dto.Quantity > product.StockQuantity)
            {
                throw new ArgumentException("Invalid quantity");
            }


            if (!product.Available)
            {
                throw new ArgumentException("Product is not available");
            }


            var cart = await _cartRepository.GetCartByUserId(userId);


            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
            }

            // Kiểm tra và thêm/sửa CartItem
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == dto.ProductId);
            if (cartItem != null)
            {
                cartItem.Quantity += dto.Quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                };
                cart.CartItems.Add(cartItem);
            }

        
            var updatedCart = await _cartRepository.AddToCart(cart);
            var cartdto = new CartDto
            {
                CartId = updatedCart.CartId,
                UserId = updatedCart.UserId,
                Items = updatedCart.CartItems.Select(ci => new CartItemDto
                {
                    CartItemId= ci.CartItemId,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    ProductName = ci.Product.Name,
                    Image = ci.Product.ImageUrl,
                    Price =ci.Product.Price

                   
                }).ToList()
            };
          

            return cartdto;
        }


        public async Task<CartDto> PutCartQuantity (int userId , PutCartQuantityDto dto)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var cart = await _cartRepository.GetCartByUserId(userId);

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == dto.CartItemId);
            if (cartItem == null) throw new ArgumentException("Cart item not found");

            if (dto.Quantity <= 0 )
            {
                cart.CartItems.Remove(cartItem);
            }
            else
            {
                cartItem.Quantity = dto.Quantity;
            }

              
           _cartItemRepository.PutCartQuantity(cartItem);
          await  _cartRepository.SaveChangesAsync();
            return new CartDto
            {
               CartId = cart.CartId,
               UserId = cart.UserId,
                Items = cart.CartItems.Select(ci => new CartItemDto
                {
                    CartItemId = ci.CartItemId,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Image = ci.Product.ImageUrl,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity
                }).ToList()


            }; 

        }


        public async Task<string> DeleteCartItem (int userId, int CartItemId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var cart = await _cartRepository.GetCartByUserId(userId);

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == CartItemId);
            if (cartItem is null)
            {
                throw new Exception("you have choose the product to delete ");
            }
            _cartItemRepository.DeleteCartItem(cartItem);
            await _cartRepository.SaveChangesAsync();
            return "Cart item deleted successfully";

        }


        public async Task<string> DeleteCart (int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var cart = await _cartRepository.GetCartByUserId(userId);
            if (cart is null)
            {
                throw new Exception("your cart is empty");

            }
            _cartRepository.DeleteCart(cart);
            await _cartRepository.SaveChangesAsync();
            return ("your cart has been deleted ");
        }

    }
}
