using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;

namespace UserUsingFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetUsersList();
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var users = _userService.GetUserDetailsById(id);
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
       /* [HttpPost]
        [Route("[action]")]
        public IActionResult SaveUser(User userModel)
        {
            try
            {
                var model = _userService.SaveUser(userModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }*/
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddUser(User userModel)
        {
            try
            {
                var model = _userService.AddUser(userModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateUser(User userModel)
        {
            try
            {
                var model = _userService.UpdateUser(userModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var model = _userService.DeleteUser(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
