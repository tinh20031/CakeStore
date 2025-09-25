using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task AddOrderDetail(OrderDetails orderDetails);
        Task<bool> SaveChangesAsync();
    }
}
