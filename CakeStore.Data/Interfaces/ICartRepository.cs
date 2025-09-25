using CakeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CakeStore.Data.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserId (int userId );
        Task <Cart> AddToCart (Cart cart );
        Task<Cart> GetCartById (int id);
        void DeleteCart (Cart cart);
        void UpdateCart (Cart cart);
  
        Task<bool> SaveChangesAsync();
        
    }
}
