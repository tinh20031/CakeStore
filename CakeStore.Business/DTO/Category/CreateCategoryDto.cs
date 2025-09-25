using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.DTO.Categorry
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
