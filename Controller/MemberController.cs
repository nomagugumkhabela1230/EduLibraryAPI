using System.IdentityModel.Tokens.Jwt;
using LibraryAPI.Domain.DTOs.MemberDTOs;
using LibraryAPI.Services.MemberService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        /// <summary>
        /// Retrieves the current user or creates a new member from Microsoft token claims.
        /// </summary>


     [Authorize]
     [HttpGet("Auth")]
    public async Task<IActionResult> ValidateTokenAndAddEmployee()
    {
        var authHeader = Request.Headers["Authorization"].FirstOrDefault();

        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            return Unauthorized("Missing or invalid Authorization header");

        var token = authHeader.Substring("Bearer ".Length).Trim();

        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken;

        try
        {
            jwtToken = handler.ReadJwtToken(token);
        }
        catch
        {
            return BadRequest("Invalid JWT token");
        }
            var MicrosoftId = jwtToken.Claims.FirstOrDefault(c => c.Type == "oid")?.Value;
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var FullName = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
            
     if (string.IsNullOrWhiteSpace(MicrosoftId) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(FullName))
{
    return BadRequest("One or more required claims (oid, email, name) are missing in the JWT token.");
}


            await _memberService.GetorCreateMemberFromTokenClaimsAsync(MicrosoftId, email, FullName);

            return Ok(new { message = "successfully added" });
        }

    }
}