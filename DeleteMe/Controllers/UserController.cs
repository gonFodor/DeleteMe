using System.Linq;
using DeleteMe.Data;
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
        public IActionResult GetUsers()
        {
            return Ok(_users.GetAllUsers());
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