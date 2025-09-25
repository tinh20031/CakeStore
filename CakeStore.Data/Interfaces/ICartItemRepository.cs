using CakeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Interfaces
{
    public interface ICartItemRepository

    {
        Task <IEnumerable<CartItem>> GetCartItemsByIds(int[] cartItemIds);
        void PutCartQuantity(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);

    }
}
