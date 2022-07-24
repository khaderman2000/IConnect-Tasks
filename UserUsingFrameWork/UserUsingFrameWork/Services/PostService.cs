using UserUsingFrameWork.Models;
using UserUsingFrameWork.ViewModels;

namespace UserUsingFrameWork.Services
{
    public class PostService : IPostService
    {
        private UserContext _context;
        public PostService(UserContext context)
        {
            _context = context;
        }
        public ResponseModel AddPost(Post postModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                _context.Add<Post>(postModel);
                model.Messsage = "Post Inserted Successfully";
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeletePost(int postId)
        {

            ResponseModel model = new ResponseModel();
            try
            {
                Post _temp = GetPostDetailsById(postId);
                if (_temp != null)
                {
                    _context.Remove<Post>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Post Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public Post GetPostDetailsById(int postId)
        {
            Post post;
            try
            {
                post = _context.Find<Post>(postId);
            }
            catch (Exception)
            {
                throw;
            }
            return post;

        }

        public List<Post> GetPostList()
        {
            List<Post> postList;
            try
            {
                postList = _context.Set<Post>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return postList;

        }

        public ResponseModel UpdatePost(Post postModel)
        {

            ResponseModel model = new ResponseModel();
            try
            {
                Post _temp = GetPostDetailsById(postModel.Id);
                if (_temp != null)
                {
                    _temp.Title= postModel.Title;

                    _context.Update<Post>(_temp);
                    model.Messsage = "Post Update Successfully";
                    _context.SaveChanges();
                    model.IsSuccess = true;
                }
                else
                {

                    model.Messsage = "Can't find the Post";
                }

            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
