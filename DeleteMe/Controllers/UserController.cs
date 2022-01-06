using System.Threading.Tasks;
using DeleteMe.Interfaces;
using DeleteMe.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeleteMe.Controllers
{
    [ApiController]
    public class UserController:Controller
    {
        private readonly IUsers _users;

        public UserController(IUsers users)
        {
            _users = users;
        }

        [HttpGet("api/users")]
        public async Task<IActionResult>  GetUsers()
        {
            return Ok(await _users.GetAllUsers());
        }

        [HttpDelete("api/users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _users.IsUserExist(id))
            {
                await _users.DeleteUser(id);
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPost("api/users/{name}&{role}")]
        public async Task<IActionResult> AddUser(string name, Roles role)
        {
            await _users.AddUser(name, role);
            return Ok();
        }

        [HttpPatch("api/users/{id}&{name}")]
        public async Task<IActionResult> EditUserName(int id, string name)
        {
            await _users.EditUserName(id,name);
            return Ok();
        }
        
        [HttpPatch("api/users/{id}&{role}")]
        public async Task<IActionResult> EditUserRole(int id, Roles role)
        {
            await _users.EditUserRole(id,role);
            return Ok();
        }

        [HttpGet("api/users/{name}")]
        public async Task<IActionResult> SearchUser(string name)
        {
            
            return Ok(await _users.SearchUser(name));
        }
        /*[HttpGet("api/users1")]
        public IActionResult CreateUser()
        {
            _appDbContext.Users.Add(new User {Name = "Vupsen", Role = Roles.Client, Wallet = 10});
            _appDbContext.SaveChanges();
            return Ok();
        }*/

    }
}