using CompanyMember.Enums;
using CompanyMember.Exceptions;
using CompanyMember.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMember.Repository
{
	public class UserRepository
	{
		private List<User> users = new List<User>()
		{
			 new User(2, "Lal", "Krishna", "lalkrishna@gmail.com", 123, "123", Roles.JobProvider), new User(2, "Raj", "Ram", "jobProvider@gmail.com", 123, "123", Roles.JobProvider) 
		};
		private int nextId = 3;
	

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
			var user= users.FirstOrDefault(e => e.Email == email && e.Password == password);
			return user;

		}
	}
}

