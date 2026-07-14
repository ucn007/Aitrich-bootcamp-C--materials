
using JobProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProvider.Interface
{
    public interface IUserRepository
    {
        List<User> getAll();
        bool register(User user);
    }
}
