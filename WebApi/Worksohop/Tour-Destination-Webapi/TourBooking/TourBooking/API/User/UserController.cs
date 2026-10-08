using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourBooking.Controllers;
using Domain.Models;
using Domain.Services.User.Interface;
using Domain.Services.User.DTO;
using AutoMapper;
using TourBooking.API.User.RequestObjects;
using System.Data;

namespace TourBooking.API.User
{
 
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : BaseApiController<UserController>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost("Registration")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            try
            {
                var dto = _mapper.Map<AddUserDto>(request);
                var result = await _userService.AddUserAsync(dto);

                var response = _mapper.Map<UserResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
       


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var dto = _mapper.Map<LoginDto>(request);
            var token = await _userService.LoginAsync(dto);
            if (token == null) return Unauthorized("Invalid credentials");

            return Ok(new { token });
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var dto = _mapper.Map<ForgotPasswordDto>(request);
            var token = await _userService.ForgotPasswordAsync(dto);

            if (string.IsNullOrEmpty(token))
                return NotFound("User not found with this email.");

            // Optionally return token in body (client uses it in next step)
            return Ok(new
            {
                Message = "Verification code has been sent to your email.",
                VerificationToken = token
            });
        }

        [HttpPost("VerifyCode")]
        public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeRequest request)
        {
            var dto = _mapper.Map<VerifyCodeDto>(request);
            var jwtToken = await _userService.VerifyCodeAsync(dto);

            if (string.IsNullOrEmpty(jwtToken))
                return BadRequest("Invalid or expired verification code.");

            return Ok(new { Token = jwtToken });
        }
        [Authorize(Roles = "AGENCY,CUSTOMER,CONSULTANT")]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var dto = _mapper.Map<ResetPasswordDto>(request);
            var result = await _userService.ResetPasswordAsync(dto);
            if (!result) return BadRequest("Invalid or expired token.");
            return Ok("Password has been reset successfully.");
        }


       
        [Authorize(Roles = "AGENCY,CUSTOMER,CONSULTANT")]
        [HttpGet("LoggedUser")]
        public async Task<IActionResult> GetLoggedUser()
        {
            try
            {
                // Extract userId from JWT claims
                var userId = User.FindFirst("UserId")?.Value;
                if (string.IsNullOrEmpty(userId)) return Unauthorized("User ID not found in token.");

                var user = await _userService.GetUserByIdAsync(Guid.Parse(userId));
                if (user == null) return NotFound("User not found.");

                var response = _mapper.Map<UserResponse>(user);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }

}

