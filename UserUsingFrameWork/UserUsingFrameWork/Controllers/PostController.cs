using Microsoft.AspNetCore.Mvc;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;

namespace UserUsingFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        INewPostService _postService;
        public PostController(INewPostService service)
        {
            _postService = service;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllPosts()
        {
            try
            { 
               var posts = _postService.Get();
               if (posts == null) return NotFound();
               return Ok();
            }
            catch (Exception)
            {
                throw new Exception("Error: cant get all user");
            }
        }
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                var posts = _postService.GetId(id);
                if (posts == null) return NotFound();
                return Ok(posts);
            }
            catch (Exception)
            {
                throw new Exception("Error: unvaild Id ");
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
        public IActionResult AddPosts([FromBody]Post postModel)
        {

            try
            {
                var model = _postService.Add(postModel);
                return Ok(model);
            }
            catch (Exception)
            {

                throw new Exception("Error:there is no User with Id: "+postModel.UserId+" , or check database ");
            } 
                
            
               
           
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdatePost(Post postModel)
        {
            try
            {
                var model = _postService.Update(postModel);
                return Ok(model);
            }
            catch (Exception)
            {
                throw new Exception("Error: Cant find User with Id :" + postModel.UserId);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeletePost(int id)
        {
            try
            {
                _postService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("cant delete User with Id" + id);
            }
        }
    }
}
