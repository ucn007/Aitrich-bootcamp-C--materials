using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProvider.Model
{
    public class JobProvider
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public JobProvider(int id, string firstname, string lastname, string email, string designation, string password)
        {
            Id = id; 
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Designation = designation;
            Password = password;


        }

        public JobProvider()
        {
        }
    }
}
