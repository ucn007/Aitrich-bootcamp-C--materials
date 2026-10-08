using Domain.Services.User.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using AutoMapper;
using Domain.Services.User.DTO;
using Azure.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Azure.Core;
using Domain.Enums;
using System.Net.Mail;
using System.Net;


namespace Domain.Services.User
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly string secretKey = "SuperSecretKey123!";

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> AddUserAsync(AddUserDto dto)
        {
            var existingUser = await _userRepository.GetByUserNameOrEmailAsync(dto.UserName, dto.Email);
            if (existingUser != null)
            {
                throw new Exception("User with the same username or email already exists.");
               
            }
            
            var user = _mapper.Map<AuthUser>(dto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;
            user.Role = UserRole.CUSTOMER;
            var saved = await _userRepository.AddUserAsync(user);
            return _mapper.Map<UserResponseDto>(saved);
        }
       

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.LoginAsync(dto.UserName, dto.Password);
            if (user == null) return null;

            // Generate JWT Token using the separate method
            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(AuthUser user)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
        new Claim("UserId", user.Id.ToString()),
        new Claim(ClaimTypes.Role, user.Role.ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null) return null; // do not reveal if email exists

            // Generate 6-digit numeric code
            var rng = new Random();
            var code = rng.Next(100000, 999999).ToString();

            // Token expiration 10 minutes
            var expires = DateTime.UtcNow.AddMinutes(30);

            // Compute HMAC hash of email|code|expiry
            var payload = $"{dto.Email}|{code}|{expires.Ticks}";
            var hash = ComputeHmac(payload);
           
            // Create verification token (base64)
            var verificationToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{dto.Email}|{expires.Ticks}|{hash}"));

            // Send email with code (async)
            await SendEmailAsync(dto.Email, " Forgot Password Reset Code", $"Your verification code is: {code}");

            // Return verification token to client (code is in email)
            return verificationToken;
        }
        private string ComputeHmac(string input)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hashBytes);
        }
        // 2️⃣ Verify code - generate JWT
        public async Task<string> VerifyCodeAsync(VerifyCodeDto dto)
        {
            try
            {
                var tokenBytes = Convert.FromBase64String(dto.VerificationToken);
                var tokenData = Encoding.UTF8.GetString(tokenBytes).Split('|');
                var email = tokenData[0];
                var ticks = long.Parse(tokenData[1]);
                var hash = tokenData[2];

                var expires = new DateTime(ticks);
                if (DateTime.UtcNow > expires) return null; // expired

                // Recompute HMAC
                var payload = $"{email}|{dto.Code}|{ticks}";
                var computedHash = ComputeHmac(payload);

                if (computedHash != hash || email != dto.Email) return null; // invalid code

                // Code valid - generate JWT
                var user = await _userRepository.GetByEmailAsync(dto.Email);
                return GenerateJwtToken(user);
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null ) return false;

            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            //user.PasswordResetToken = null;
            //user.TokenExpiry = null;

            await _userRepository.UpdateUserAsync(user);
            return true;
        }
       
            

        public async Task<UserResponseDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserResponseDto>(user);
        }

             
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var host = _config["Email:SmtpHost"];
                var portString = _config["Email:SmtpPort"];
                var user = _config["Email:SmtpUser"];
                var pass = _config["Email:SmtpPass"];
                var enableSslString = _config["Email:EnableSSL"];

                if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                    throw new Exception("Email configuration is missing in appsettings.json.");

                int port = 587; // default
                if (!string.IsNullOrEmpty(portString))
                    int.TryParse(portString, out port);

                bool enableSsl = true;
                if (!string.IsNullOrEmpty(enableSslString))
                    bool.TryParse(enableSslString, out enableSsl);

                using var client = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(user, pass),
                    EnableSsl = enableSsl,
                     UseDefaultCredentials = false
                };

                using var message = new MailMessage(user, toEmail, subject, body)
                {
                    IsBodyHtml = true
                };

                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Email send failed: {ex.Message}", ex);
            }
        }



    }
}

