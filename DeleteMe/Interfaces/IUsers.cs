using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeleteMe.Models;

namespace DeleteMe.Interfaces
{
    public interface IUsers
    {
        Task AddUser(string name, Roles role = Roles.Client);

        Task <IEnumerable<User>> GetAllUsers();
        Task DeleteUser(int id);
        Task EditUserName(int id, string name);
        Task EditUserRole(int id, Roles roles);
        Task<IEnumerable<User>>  SearchUser(string name);
        Task <bool> IsUserExist(int id);
    }
}