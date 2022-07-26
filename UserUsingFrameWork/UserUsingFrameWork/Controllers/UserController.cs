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
        INewUserService _userService;
        public UserController(INewUserService service)
        {
            _userService = service;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.Get();
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
        public IActionResult GetId(int id)
        {
            try
            {
                var users = _userService.GetId(id);
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
                var model = _userService.Add(userModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdatUser(User userModel)
        {
            try
            {
                var model = _userService.Update(userModel);
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
                 _userService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
