using mvc_machinetest.Data;
using mvc_machinetest.Interfaces;
using mvc_machinetest.Models;

namespace mvc_machinetest.Repository;

public class AdminRepository:IAdminRepository
{
    private readonly MyDbContext _dbContext;

    public AdminRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async  Task<Admin?> GetByEmailAsync(string email)
    {
        return _dbContext.Admins.FirstOrDefault(a => a.Email == email);
    }

    public async  Task<Admin?> GetByIdAsync(int id)
    {
        return _dbContext.Admins.FirstOrDefault(a => a.Id == id);
    }

    public async  Task<List<Admin>> GetAllAsync()
    {
        return _dbContext.Admins.ToList();
    }

    public async Task<Admin> CreateAsync(Admin admin)
    {
        _dbContext.Admins.Add(admin);
        await _dbContext.SaveChangesAsync();
        return admin;
    }
}