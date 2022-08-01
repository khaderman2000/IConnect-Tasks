using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserController(INewUserService service, IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users =await _userService.Get();
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
                var users = await  _userService.GetId(id);
                
                return Ok(_mapper.Map<UserVM>(users));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUser(UserVM userModel)
        {
            try
            {
                var model = await _userService.Add(_mapper.Map<User>(userModel));
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdatUser(UserVM userModel)
        {
            try
            {
                var model = _userService.Update(_mapper.Map<User>(userModel));
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
