using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;

namespace UserUsingFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        INewUserService _userService;
        private readonly IMapper _mapper;
        public UserController(INewUserService service, IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.Get<UserVM>();
                return Ok(_mapper.Map<List<UserVM>>(users));
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
                var users = await _userService.GetId<UserVM>(id);

                return Ok(_mapper.Map<UserVM>(users));
            }
                   catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> AddUser(UserVM userModel)
        {
            try
            {
                  var id = User.FindFirst(ClaimTypes.Sid)?.Value;

                var model = await _userService.Add(_mapper.Map<User>(userModel),int.Parse(id));
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("[action]")]
        [Authorize]
        public IActionResult UpdatUser(UserVM userModel)
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.Sid)?.Value;
                var model = _userService.Update(_mapper.Map<User>(userModel),int.Parse(id));
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
                await _userService.Delete<UserVM>(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}