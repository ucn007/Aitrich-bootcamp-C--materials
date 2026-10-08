using BCrypt.Net;
using EmailOne.DTOs;
using EmailOne.Models;
using EmailOne.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Org.BouncyCastle.Crypto.Generators;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IEmailService _emailService;

    public AuthController(
        AppDbContext context,
        IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (existingUser != null)
            return BadRequest("Email already exists");

        string token = Guid.NewGuid().ToString();

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            VerificationToken = token,
            IsEmailVerified = false
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        string verificationLink =
            $"https://localhost:7068/api/auth/verify-email?token={token}";

        string body = $@"
            <h2>Email Verification</h2>
            <p>Please click the link below:</p>
            <a href='{verificationLink}'>
                Verify Email
            </a>";

        await _emailService.SendEmailAsync(
            dto.Email,
            "Verify Your Email",
            body);

        return Ok("Registration successful. Check your email.");
    }

    [HttpGet("verify-email")]
    public async Task<IActionResult> VerifyEmail(string token)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.VerificationToken == token);

        if (user == null)
            return BadRequest("Invalid token");

        user.IsEmailVerified = true;
        user.VerificationToken = null;

        await _context.SaveChangesAsync();

        return Ok("Email verified successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user == null)
            return Unauthorized("Invalid credentials");

        bool validPassword =
            BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

        if (!validPassword)
            return Unauthorized("Invalid credentials");

        if (!user.IsEmailVerified)
            return BadRequest("Please verify your email first");

        return Ok("Login successful");
    }
}
