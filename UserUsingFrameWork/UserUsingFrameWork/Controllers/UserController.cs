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
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users =await  _userService.Get();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var users = await  _userService.GetId(id);
                
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
        public async Task<IActionResult> AddUser(User userModel)
        {
            try
            {

                var model = await _userService.Add(userModel);
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await  _userService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
