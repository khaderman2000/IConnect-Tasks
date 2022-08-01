using Microsoft.AspNetCore.Mvc;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;
using AutoMapper;

namespace UserUsingFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        //[ServiceFilter(typeof(Roles))]
        public  async Task<IActionResult> GetAllPosts()
        { 
            try
            { 
               var posts = await _postService.Get();
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
                var posts =await _postService.GetId(id);
                if (posts == null) return NotFound();
                return Ok(_mapper.Map<PostVM>(posts));
            }
            catch (Exception)
            {
                throw new Exception("Error: unvaild Id ");
            }
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPosts([FromBody]PostVM postModel)
        {

            try
            {
                var model =await   _postService.Add(_mapper.Map<Post>(postModel));
                return Ok(model);
            }
            catch (Exception)
            {

                throw new Exception("Error:there is no User with Id: "+postModel.UserId+" , or check database ");
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
              await _postService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("cant delete User with Id:" + id);
            }
        }
    }
}
