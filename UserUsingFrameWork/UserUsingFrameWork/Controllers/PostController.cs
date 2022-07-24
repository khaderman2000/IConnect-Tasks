using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;

namespace UserUsingFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _postService;
        public PostController(IPostService service)
        {
            _postService = service;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllPosts()
        {
            try
            {
                var posts = _postService.GetPostList();
                if (posts == null) return NotFound();
                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                var posts = _postService.GetPostDetailsById(id);
                if (posts == null) return NotFound();
                return Ok(posts);
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
        public IActionResult AddPosts([FromBody]Post postModel)
        {
            try
            {
                var model = _postService.AddPost(postModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdatePost(Post postModel)
        {
            try
            {
                var model = _postService.UpdatePost(postModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeletePost(int id)
        {
            try
            {
                var model = _postService.DeletePost(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
