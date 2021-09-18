using ConnectingPlusAPI.Data;
using ConnectingPlusAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository = new UserRepository();
        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{username}")]
        public ActionResult<User> GetUserByUser(string username)
        {
            var user = _repository.GetUserByUser(username);
            return Ok(user);
        }
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            _repository.CreateUser(user);
            return Ok();
        }
        [HttpPut("{username}")]
        public ActionResult UpdateUser(string username, User user)
        {
            var temp = _repository.GetUserByUser(username);
            if (temp != null)
            {
                _repository.UpdateUser(username, user);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{username}")]
        public ActionResult DeleteUser(string username)
        {
            var user = _repository.GetUserByUser(username);
            if (user != null)
            {
                _repository.DeleteUser(username);
                return Ok();
            }
            return NotFound();
        }
    }
}
