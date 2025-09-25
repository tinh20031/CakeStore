using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.DTO.Order
{
    public class RequestOrderDto
    {
        public int [] CartItemIds { get; set; } 
        public string note { get; set; }
        public DateTimeOffset PickupDate { get; set; }
        public string Address { get; set; } 

    }
}
