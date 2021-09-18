using ConnectingPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public interface IUserRepository
    {
        User GetUserByUser(string username);
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(string username, User user);
        void DeleteUser(string username);
    }
}
