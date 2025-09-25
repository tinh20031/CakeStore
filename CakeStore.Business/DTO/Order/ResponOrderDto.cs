using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.DTO.Order
{
    public class ResponOrderDto
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset PickupDate { get; set; }
        public decimal TotalAmount { get; set; }
        public status Status { get; set; }
        public string? Note { get; set; }
        public string Address { get; set; }
        public List<ProductOfOrderDto> Products { get; set; } = new();
    }


        public class ProductOfOrderDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

    }
}
