
using Admin_Job.Enums;
using JobSeeker.Exceptions;
using JobSeeker.Interfaces;
using JobSeeker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Repository
{
    public sealed class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        private int nextId = 1;
    
       
        public List<User> getAll()
        {
            return users.Where(e => e.Role == Roles.JobSeeker).ToList();
        }
        public List<User> get(int id)
        {
            return users.Where(e => e.Id == id).ToList();
        }
        public bool register(User user)
        {
            user.Id = nextId;
            user.Role = Roles.JobSeeker;
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
