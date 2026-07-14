using JobSeeker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Interfaces
{
    public interface IUserRepository 
    {
        List<User> getAll();
        bool register(User user);

    }
}
