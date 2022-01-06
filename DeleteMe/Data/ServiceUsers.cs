using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeleteMe.Interfaces;
using DeleteMe.Models;
using Microsoft.EntityFrameworkCore;


namespace DeleteMe.Data
{
    public class ServiceUsers : IUsers
    {
        private AppDbContext _appDbContext;

        public ServiceUsers(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task AddUser(string name, Roles role)
        {
            _appDbContext.Users.Add(new User {Name = name, Role = role});
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User> > GetAllUsers()
        {
            return await _appDbContext.Users.Select(x => new User {Id = x.Id, Name = x.Name, Role = x.Role, Wallet = x.Wallet}).ToListAsync();
        }

        public async Task DeleteUser(int id)
        {
            var deleteUser = _appDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (deleteUser == null) return;
            _appDbContext.Users.Remove(deleteUser);
            await _appDbContext.SaveChangesAsync();
        }

        public Task<bool> IsUserExist(int id)
        {
            return _appDbContext.Users.AnyAsync(x => x.Id == id);
        }
        public async Task EditUserName(int id, string name)
        {
            var editUser = _appDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (editUser == null) return;
            editUser.Name = name;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditUserRole(int id, Roles role)
        {
            var editUser = _appDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (editUser == null) return;
            editUser.Role = role;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> SearchUser(string name)
        {
            
            return await _appDbContext.Users.Where(x => x.Name.Contains(name)).ToListAsync();
            
          
        }
    }
}