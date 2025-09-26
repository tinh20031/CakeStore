
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
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration, IPasswordHasher<User> passwordHasher, IEmailService emailService)
        {
            _authRepository = authRepository;
            _configuration = configuration;

            _passwordHasher = passwordHasher;
            _emailService = emailService;
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
            var emailToken = GenerateEmailVerificationToken();
            string htmlTemplate = @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>CakeStore Email Verification</title>
</head>
<body style=""margin: 0; padding: 0; font-family: Arial, Helvetica, sans-serif; background-color: #f9ecef;"">
    <table role=""presentation"" width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 12px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);"">
        <!-- Header -->
        <tr>
            <td style=""background-color: #ff85ad; text-align: center; padding: 30px; border-top-left-radius: 12px; border-top-right-radius: 12px;"">
                <img src=""https://your-cakestore.com/logo.png"" alt=""CakeStore Logo"" style=""max-width: 140px; height: auto;"">
                <h1 style=""color: #ffffff; font-size: 26px; margin: 15px 0; font-weight: bold;"">Welcome to CakeStore!</h1>
            </td>
        </tr>
        <!-- Body -->
        <tr>
            <td style=""padding: 40px 30px; text-align: center; color: #333333;"">
                <h2 style=""font-size: 22px; margin-bottom: 20px; font-weight: bold;"">Verify Your Email</h2>
                <p style=""font-size: 16px; line-height: 1.6; margin-bottom: 25px;"">
                    Thank you for joining CakeStore! Please use the code below to verify your email address and start enjoying our delicious cakes.
                </p>
                <div style=""background-color: #fff0f5; border: 2px dashed #ff6699; border-radius: 8px; padding: 20px; margin: 20px 0; font-size: 24px; font-weight: bold; color: #ff3366; letter-spacing: 2px;"">
                    {emailToken}
                </div>
                <p style=""font-size: 14px; color: #666666; line-height: 1.5;"">
                    Enter this code on the verification page to activate your account. The code is valid for 15 minutes.
                </p>
            </td>
        </tr>
        <!-- Footer -->
        <tr>
            <td style=""background-color: #f9ecef; text-align: center; padding: 20px; border-bottom-left-radius: 12px; border-bottom-right-radius: 12px;"">
                <p style=""font-size: 14px; color: #666666; margin: 0; line-height: 1.5;"">
                    &copy; 2025 CakeStore. All rights reserved.<br>
                    Questions? Reach out at <a href=""mailto:support@your-cakestore.com"" style=""color: #ff6699; text-decoration: none;"">support@your-cakestore.com</a>
                </p>
            </td>
        </tr>
    </table>
</body>
</html>";

            // Replace placeholder with actual email token
            string emailBody = htmlTemplate.Replace("{emailToken}", emailToken);
            await _emailService.SendEmailAsync(user.Email, "Email Verification - CakeStore", emailBody);
            user.EmailVerificationTokenExpiry = DateTimeOffset.UtcNow.AddMinutes(15);
            user.EmailVerificationToken = emailToken;
            await _authRepository.UpdateUser(user);
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
        private string GenerateEmailVerificationToken(int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var data = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }
            var result = new StringBuilder(length);
            foreach (var b in data)
            {
                result.Append(chars[b % chars.Length]);
            }
            return result.ToString();
        }

        public async Task<bool> VerifyTokenEmail(string email, string token)
        {
          email = email.Trim();
            token = token.Trim().ToUpper();
            var user = await _authRepository.Login(email);
            if (user == null || user.EmailVerificationToken != token || user.EmailVerificationTokenExpiry <= DateTimeOffset.UtcNow)
            {
                throw new Exception("Invalid or expired token");
            }
            user.IsEmailVerified = true;
            user.EmailVerificationToken = null;
            user.EmailVerificationTokenExpiry = null;
           await _authRepository.UpdateUser(user);
            return true;
        }

        public async Task<bool> ResendVerificationEmail(string email)
        {
            email = email.Trim();
            var user = await _authRepository.Login(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (user.IsEmailVerified)
            {
                throw new Exception("Email is already verified");
            }
            var emailToken = GenerateEmailVerificationToken();
            user.EmailVerificationToken = emailToken;
            user.EmailVerificationTokenExpiry = DateTimeOffset.UtcNow.AddMinutes(15);
            await _authRepository.UpdateUser(user);
            string htmlTemplate = @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>CakeStore Email Verification</title>
</head>
<body style=""margin: 0; padding: 0; font-family: Arial, Helvetica, sans-serif; background-color: #f9ecef;"">
    <table role=""presentation"" width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 12px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);"">
        <tr>
            <td style=""background-color: #ff85ad; text-align: center; padding: 30px; border-top-left-radius: 12px; border-top-right-radius: 12px;"">
                <img src=""https://your-cakestore.com/logo.png"" alt=""CakeStore Logo"" style=""max-width: 140px; height: auto;"">
                <h1 style=""color: #ffffff; font-size: 26px; margin: 15px 0; font-weight: bold;"">CakeStore Verification Code</h1>
            </td>
        </tr>
        <tr>
            <td style=""padding: 40px 30px; text-align: center; color: #333333;"">
                <h2 style=""font-size: 22px; margin-bottom: 20px; font-weight: bold;"">Your New Verification Code</h2>
                <p style=""font-size: 16px; line-height: 1.6; margin-bottom: 25px;"">
                    It looks like you need a new verification code for CakeStore. Use the code below to verify your email address.
                </p>
                <div style=""background-color: #fff0f5; border: 2px dashed #ff6699; border-radius: 8px; padding: 20px; margin: 20px 0; font-size: 24px; font-weight: bold; color: #ff3366; letter-spacing: 2px;"">
                    {emailToken}
                </div>
                <p style=""font-size: 14px; color: #666666; line-height: 1.5;"">
                    Enter this code on the verification page to activate your account. The code is valid for 15 minutes.
                </p>
            </td>
        </tr>
        <tr>
            <td style=""background-color: #f9ecef; text-align: center; padding: 20px; border-bottom-left-radius: 12px; border-bottom-right-radius: 12px;"">
                <p style=""font-size: 14px; color: #666666; margin: 0; line-height: 1.5;"">
                    &copy; 2025 CakeStore. All rights reserved.<br>
                    Questions? Reach out at <a href=""mailto:support@your-cakestore.com"" style=""color: #ff6699; text-decoration: none;"">support@your-cakestore.com</a>
                </p>
            </td>
        </tr>
    </table>
</body>
</html>";

            string emailBody = htmlTemplate.Replace("{emailToken}", emailToken);
            try
            {
                await _emailService.SendEmailAsync(user.Email, "New Verification Code - CakeStore", emailBody);
                return true;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Failed to send verification code");
            }
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

        private async Task<User> ValidateRefreshToken(int userid, string refresherToken)
        {
            var user = await _authRepository.GetUserId(userid);
            if (user == null || user.RefreshToken != refresherToken || user.RefreshTokenExpiryTime <= DateTimeOffset.UtcNow)
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
            return refreshToken;
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


        public async Task<ChangePassDto> ChangePassword(int userid, ChangePassDto dto)
        {
            var user = await _authRepository.GetUser(userid);
            if (user is null)
            {
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
