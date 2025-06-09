
using LibraryAPI.DTOs.AuthenticationDTOs;
using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Services.AuthService.Register;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
           _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully" });
            }

            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new { Errors = errors });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
                return Unauthorized(new { Message = "Invalid Email or password" });

            return Ok(new { Token = token });
        }


    }
}
