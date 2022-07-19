using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repo;
namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet ]
        public ActionResult<List<User>> GetAll()
        {
            return UserRepo.GetAll();
        }
        [HttpGet]
        public ActionResult<User> Get(int id)
        {
            return UserRepo.Get(id);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            UserRepo.Add(user);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var user = UserRepo.Get(id);
            if (user == null)
                return NotFound();
            UserRepo.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(int id, User user)
        {
            UserRepo.Update(id, user);
            return Ok();
        }

    }
}
