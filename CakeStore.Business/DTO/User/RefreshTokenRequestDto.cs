using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.DTO.User
{
    public class RefreshTokenRequestDto
    {
        public int  UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
