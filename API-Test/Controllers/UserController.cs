using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add_user")]
        public Result Add([FromBody] User user)
        {
            return _userService.AddUser(user);
        }

        [HttpPost("delete_user")]
        public Result Delete([FromBody] User user)
        {
            return _userService.DeleteUser(user);
        }

        [HttpPost("update_user")]
        public Result Update([FromBody] User user)
        {
            return _userService.UpdateUser(user);
        }

        [HttpGet("list_users")]
        public DataResult<List<User>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost("get_user")]
        public DataResult<User> GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }
    }
}
