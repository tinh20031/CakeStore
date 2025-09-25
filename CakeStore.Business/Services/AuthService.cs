
using CakeStore.Business.DTO.User;
using CakeStore.Business.Interfaces;
using CakeStore.Data.Interfaces;
using CakeStoreAPI.Models;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration,  IPasswordHasher<User> passwordHasher)
        {
            _authRepository = authRepository;
            _configuration = configuration;

            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> Register(RegisterUserDto dto)
        {
            var existing = await _authRepository.Login(dto.Email);
            if (existing != null)
            {
                throw new Exception("Email already exists");
            }
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new Exception("Password and Confirm Password do not match");
            }
            var user = new User
            {

                Name = dto.Name,
                Email = dto.Email,
                Created_At = DateTimeOffset.UtcNow,
                Updated_At = DateTimeOffset.UtcNow

            };
              user.Password = _passwordHasher.HashPassword(user, dto.Password);


            var result = await _authRepository.Register(user);
            if (!result)
            {
                throw new Exception("Failed to register user");
            }
            var userDto = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Token = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshTokens(user),
                Phone = user.Phone,
                Address = user.Address,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Image = user.Image

            };
            return userDto;
        }

        private string CreateToken(User user)
        {
            var Claim = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken
            (
               issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: _configuration.GetValue<string>("Jwt:Audience"),
                claims: Claim,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds

                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        private string GenerateRefresherTokens()
        {
            var ramdomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(ramdomNumber);
            return Convert.ToBase64String(ramdomNumber);
        }

        private async Task<User> ValidateRefreshToken ( int  userid, string refresherToken)
        {
            var user = await _authRepository.GetUserId(userid);
            if(user == null || user.RefreshToken != refresherToken || user.RefreshTokenExpiryTime <= DateTimeOffset.UtcNow)
            {
                return null;
            }
            return user;
        }
        public async Task<string> GenerateAndSaveRefreshTokens(User user)
        {
            var refreshToken = GenerateRefresherTokens();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTimeOffset.UtcNow.AddDays(7);
            await _authRepository.SaveRefreshTokens(user.UserId, refreshToken);
            return  refreshToken;
        }

        public async Task<UserDto> Login(LoginUserDto dto)
        {
         
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
            {
                throw new ArgumentException("Email and password are required.");
            }

           
            var user = await _authRepository.Login(dto.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

       
            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);
            if (verifyPassword == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

         
            if (verifyPassword == PasswordVerificationResult.SuccessRehashNeeded)
            {
              
                user.Password = _passwordHasher.HashPassword(user, dto.Password);
                await _authRepository.UpdateUser(user); 
            }

            // Generate token and map to DTO
            var token = CreateToken(user);
            var userDto = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Phone = user.Phone,
                Address = user.Address,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Image = user.Image
            };
            userDto.Token = token;
            userDto.RefreshToken = await GenerateAndSaveRefreshTokens(user);

            return userDto;
        }

        public async Task<TokenResponseDto> RefreshToken(RefreshTokenRequestDto request)
        {
            var user = await ValidateRefreshToken(request.UserId, request.RefreshToken);
                        if (user == null)
            {
                throw new Exception("Invalid Refresh Token");
            }
            var token = CreateToken(user);
            var refreshToken = await GenerateAndSaveRefreshTokens(user);
            return new TokenResponseDto
            {
                Token = token,
                RefreshToken = refreshToken
            };
        }


        public async Task<ChangePassDto> ChangePassword (int userid, ChangePassDto dto)
        {
            var user = await _authRepository.GetUser(userid);
            if ( user is null){
               throw new Exception("User not found");
            }
            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.OldPassword);
            Console.WriteLine($"OldPassword received: {dto.OldPassword}");
            Console.WriteLine($"Stored Hashed Password: {user.Password}");
            if (verifyPassword == PasswordVerificationResult.Failed)
            {
                throw new Exception("Old Password is incorrect");
            }
     
            if (dto.NewPassword != dto.ConfirmNewPassword)
            {
                throw new Exception("New Password and Confirm Password do not match");
            }
            user.Password = _passwordHasher.HashPassword(user, dto.NewPassword);
            user.Updated_At = DateTimeOffset.UtcNow;
            await _authRepository.SaveChangesAsync();
            return dto;


        }
    }
}
