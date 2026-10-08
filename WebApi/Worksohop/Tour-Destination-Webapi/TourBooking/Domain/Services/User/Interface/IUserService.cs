using Domain.Models;
using Domain.Services.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.User.Interface
{
    public interface IUserService
    {
        Task<UserResponseDto> AddUserAsync(AddUserDto user);
        Task<string> LoginAsync(LoginDto user);
        Task<string> ForgotPasswordAsync(ForgotPasswordDto dto);
        Task<string> VerifyCodeAsync(VerifyCodeDto dto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
        Task<UserResponseDto> GetUserByIdAsync(Guid userId);
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
