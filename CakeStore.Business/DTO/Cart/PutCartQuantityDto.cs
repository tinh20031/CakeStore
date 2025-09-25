using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.DTO.Cart
{
    public class PutCartQuantityDto
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
