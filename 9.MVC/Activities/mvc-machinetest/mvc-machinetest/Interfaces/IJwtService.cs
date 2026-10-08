using mvc_machinetest.Models;

namespace mvc_machinetest.Interfaces;

public interface IJwtService
{
    string GenerateToken(Admin admin);
}