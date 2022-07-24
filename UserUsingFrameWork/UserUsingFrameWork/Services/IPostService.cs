using UserUsingFrameWork.Models;
using UserUsingFrameWork.ViewModels;

namespace UserUsingFrameWork.Services
{
    public interface IPostService
    {
        List<Post> GetPostList();
        Post GetPostDetailsById(int postId);
        ResponseModel AddPost(Post postModel);
        ResponseModel UpdatePost(Post postModel);
        ResponseModel DeletePost(int postId);
    }
}
