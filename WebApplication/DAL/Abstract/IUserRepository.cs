using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User FindUser(int id);

        User FindUser(string userName);

        void AddUser(User user);

        void DeleteUser(User user);
    }
}
