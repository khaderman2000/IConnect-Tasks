using AutoMapper;
using UserUsingFrameWork.Models;

namespace UserUsingFrameWork.Profiles
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostVM>().ReverseMap();
        }
    }
}
