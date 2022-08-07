using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserUsingFrameWork.Models;

namespace UserUsingFrameWork.Services
{

        public interface INewPostService : IGenRepo<Post>
        {
        public Task<List<Post>?> GetPage(int page, int size, string search);


    }
    public class NewPostService : GenRepo<Post>, INewPostService
    {
        private UserContext _context;

        public NewPostService(UserContext context,IMapper mapper) : base(context,mapper)
        {
            _context = context;
        }
        public Task<List<Post>?> GetPage(int page, int size, string search)
        {
            return _context.Set<Post>().Where(x => x.Title.Contains(search)).Skip<Post>(size * page).Take<Post>(size).ToListAsync();

        }
    }
}

