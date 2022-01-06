using System.Collections;
using System.Collections.Generic;
using DeleteMe.Models;

namespace DeleteMe.Interfaces
{
    public interface IUsers
    {
        public void AddUser(string name, Roles role = Roles.Client);

        public IEnumerable<User> GetAllUsers();
        public void DeleteUser(int id);
        public void EditUserName(int id);
        public void EditUserRole(int id);
        public void SearchUser(string name);
    }
}