using CakeStore.Data.Entities;
using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        //Task<Orders> GetOrderById(int id);
        Task AddOrder(Orders orders);
        //void UpdateOrder(Orders orders);
        //void DeleteOrder(Orders orders);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<CartItem>> PreviewOrder();
    }
}
