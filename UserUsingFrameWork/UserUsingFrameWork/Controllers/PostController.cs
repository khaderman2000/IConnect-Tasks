using Microsoft.AspNetCore.Mvc;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;
using UserUsingFrameWork.Fillters;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UserUsingFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Roles]
    public class PostController : ControllerBase
    {
        INewPostService _postService;
        private readonly IMapper _mapper;
        public PostController(INewPostService service, IMapper mapper)
        {
            _postService = service;
            _mapper= mapper;
        }
        [HttpGet]
        [Route("[action]")]
        //[Roles]
        public  async Task<IActionResult> GetAllPosts()
        { 
            try
            { 
               var posts = await _postService.Get<PostVM>();
               if (posts == null) return NotFound();
               return Ok(_mapper.Map<List<PostVM>>(posts));
            }
            catch (Exception)
            {
                throw new Exception("Error: cant get all user");
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPostPages(int page, int size, string search)
        {
            try
            {
                var posts = await _postService.GetPage( page,  size,  search);
                if (posts == null) return NotFound();
                return Ok(_mapper.Map<List<PostVM>>(posts));
            }
            catch (Exception)
            {
                throw new Exception("Error: cant get all user");
            }
        }
        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            { 
                var posts =await _postService.GetId<PostVM>(id);
                 if (posts == null) return NotFound();
                return Ok(_mapper.Map<PostVM>(posts));
            }
            catch (Exception )
            {
                throw new Exception("Error: unvaild Id ");
            }
        }
        
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> AddPosts([FromBody]PostVM postModel)
        {

            try
            {
                var id = User.FindFirst(ClaimTypes.Sid)?.Value;
                postModel.UserId = int.Parse(id); 
                var model =await   _postService.Add(_mapper.Map<Post>(postModel));
                return Ok(postModel);
            }
            catch (Exception)
            {

                throw new Exception(" or check database ");
            } 
                
            
               
           
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdatePost(PostVM postModel)
        {
            try 
            { 
                var model = _postService.Update(_mapper.Map<Post>(postModel));
                return Ok(model);
            }
            catch (Exception)
            {
                throw new Exception("Error: Cant find User with Id :" + postModel.UserId);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
              await _postService.Delete<PostVM>(id);
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("cant delete User with Id:" + id);
            }
        }
    }
}
