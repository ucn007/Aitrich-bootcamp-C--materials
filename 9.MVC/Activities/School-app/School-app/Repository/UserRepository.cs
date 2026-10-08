using Microsoft.EntityFrameworkCore;
using School_app.Data;
using School_app.Models;
using School_app.Repository.Interface;

namespace School_app.Repository;

public class UserRepository:IUserRepository
{
    private readonly MyDbContext _dbContext;
    
    public UserRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users.ToListAsync();
    }
    
    public async Task<User> GetById(long id)
    {
        return await _dbContext.Users.FindAsync(id);
    }
    
    public async Task<User> GetByEmail(string email)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _dbContext.Users.FindAsync(username);
    }
    
    public async Task<User> GetByUsernameAndPassword(string username, string password)
    {
        return await _dbContext.Users.FindAsync(username, password);
    }

    public async Task<User> GetByEmailAndPassword(string email, string password)
    {
        return await _dbContext.Users.FindAsync(email, password);
    }

    public async Task<User> AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await GetById(id);

        if (user == null)
            
            return false;

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}