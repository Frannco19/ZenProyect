using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userService.AddUser(user);
            return Ok("User created successfully.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound("User not found.");
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            _userService.UpdateUser(user);
            return Ok("User updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok("User deleted successfully.");
        }
    }

}
