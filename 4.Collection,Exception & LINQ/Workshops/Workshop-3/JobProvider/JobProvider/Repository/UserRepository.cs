
using JobProvider.Enums;
using JobProvider.Exceptions;
using JobProvider.Interface;
using JobProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProvider.Repository
{
    public sealed class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        private int nextId = 2;
    
       
        public List<User> getAll()
        {
            return users.Where(e => e.Role == Roles.JobSeeker).ToList();
        }
        public bool register(User user)
        {
            user.Id = nextId;
            user.Role = Roles.JobProvider;
            nextId++;
            if (users.Find(e => e.Email == user.Email) == null)
            {
                users.Add(user);
                return true;
            }
            throw new UserAlreadyExistException(user.Email);
        }
        public User login(string email, string password)
        {
            return users.FirstOrDefault(e => e.Email == email && e.Password == password);
        }
    }
}
