using CakeStore.Business.DTO.Cart;
using CakeStore.Business.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Interfaces
{
    public interface IOrderService
    {
       Task<IEnumerable<PreviewCartDto>> PreviewOrder(int [] CartItemId, int UserId);
        Task<string> CreateOrder(RequestOrderDto dto, int UserId);
        Task<IEnumerable<ResponOrderDto>> GetAllOrders();
    }
}
