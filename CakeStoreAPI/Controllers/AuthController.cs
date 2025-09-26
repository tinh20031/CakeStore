using CakeStore.Business.DTO.User;
using CakeStore.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Security.Claims;

namespace CakeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (dto == null) return BadRequest();
            var registeredUser = await _authService.Register(dto);
            return Ok(new { message = "register successfully " });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            try
            {
                if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                {
                    return BadRequest("Email and password are required.");
                }

                var user = await _authService.Login(dto);
                return Ok(user);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid email or password.");
            }
            catch (Exception ex)
            {
         
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult check()
        {
            if (!User.IsInRole("Admin"))
            {
                return BadRequest("Only Admin can access this endpoint.");
            }
            else
            {
                return Ok("Admin access granted.");
            }


        }


        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
           
            var tokenResponse = await _authService.RefreshToken(request);
            if (tokenResponse == null|| tokenResponse.Token == null || tokenResponse.RefreshToken == null ) return Unauthorized("invalid refresh token. ");
            return Ok(tokenResponse);
        }


        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword( [FromBody] ChangePassDto dto)
        {
            if (dto == null) return BadRequest();
            var UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
          
            var updatedDto = await _authService.ChangePassword(UserId, dto);
            if (updatedDto == null) return NotFound("User not found or incorrect current password.");
            return Ok(new { message = "Password changed successfully." });
        }

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string email, [FromQuery] string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Email and token are required.");
            }
            var isVerified = await _authService.VerifyTokenEmail(email, token);
            if (!isVerified)
            {
                return BadRequest("Invalid email or token.");
            }
            return Ok(new { message = "Email verified successfully." });
        }

        [HttpPost("ResendVerificationEmail")]
        public async Task<IActionResult> ResendVerificationEmail([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email is required.");
            }
            var isSent = await _authService.ResendVerificationEmail(email);
            if (!isSent)
            {
                return BadRequest("Failed to resend verification email. Please check the email address and try again.");
            }
            return Ok(new { message = "Verification email resent successfully." });
        }



    }
}
