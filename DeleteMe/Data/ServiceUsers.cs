using System.Collections.Generic;
using System.Linq;
using DeleteMe.Interfaces;
using DeleteMe.Models;

namespace DeleteMe.Data
{
    public class ServiceUsers : IUsers
    {
        private AppDbContext _appDbContext;
        

        public void AddUser(string name, Roles role)
        {
            _appDbContext.Users.Add(new User {Name = name, Role = role});
            _appDbContext.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDbContext.Users
                .Select(x => new User {Id = x.Id, Name = x.Name, Role = x.Role, Wallet = x.Wallet}).ToList();
        }

        public void DeleteUser(int id)
        {
            
        }

        public void EditUserName(int id)
        {
            
        }

        public void EditUserRole(int id)
        {
            
        }

        public void SearchUser(string name)
        {
            
        }
    }
}