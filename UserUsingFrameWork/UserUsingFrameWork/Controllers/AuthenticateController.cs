using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;
using UserUsingFrameWork.ViewModels;

namespace UserUsingFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRoles> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        INewUserService _userService;



        public AuthenticateController(
            UserManager<User> userManager,
            RoleManager<UserRoles> roleManager,
            IConfiguration configuration,
            IMapper mapper,
            INewUserService service)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
            _userService = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserVM model)
        {
            IdentityResult result;
            var userExists = await _userManager.FindByNameAsync(_mapper.Map<User>(model).UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });

            User user = new ()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName=model.FirstName,
                LastName=model.LastName
            };


             result = await _userManager.CreateAsync(user, model.PasswordHash);
            if (result==null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });
        }
        /*
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserVM model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });

            User user = new ()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName

            };
            var result = await _userManager.CreateAsync(user, model.PasswordHash);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });

        }
        */
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
