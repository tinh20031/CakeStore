using CakeStore.Business.DTO.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Interfaces
{
    public interface ICartService
    {
        public Task<CartDto> GetCartByUserId(int userId);
        public Task<CartDto> AddToCart(int userId, AddToCartDto addToCartDto);
        public Task<CartDto> PutCartQuantity(int userId, PutCartQuantityDto dto);
        public Task<string> DeleteCartItem(int userId, int cartItemId);
        public Task<string> DeleteCart(int userId );
    }
}
