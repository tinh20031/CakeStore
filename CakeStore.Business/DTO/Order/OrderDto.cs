using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.DTO.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset PickupDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string? Note { get; set; }
        public string Address { get; set; }
    }
}
