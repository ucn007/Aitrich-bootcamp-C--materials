namespace mvc_machinetest.DTOs.Admin;

public class LoginResponse
{
    public string Token { get; set; } = null!;

    public UserResponseDto User { get; set; } = null!;
}