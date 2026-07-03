using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProvider.Interface
{
    public interface IUserRepository
    {
        public void Login();
        public void Register();
    }
}
