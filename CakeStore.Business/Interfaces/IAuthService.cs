using CakeStore.Business.DTO.User;
using CakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Interfaces
{
    public interface IAuthService
    {

        Task<UserDto> Register(RegisterUserDto dto);
        Task<UserDto> Login(LoginUserDto dto);
        Task<ChangePassDto> ChangePassword( int userid, ChangePassDto dto);
        Task<TokenResponseDto> RefreshToken(RefreshTokenRequestDto request);
        Task<bool> VerifyTokenEmail (string email, string token );  
        Task<bool> ResendVerificationEmail(string email);
    }
}
