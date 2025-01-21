using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
