﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.DTO.User
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
