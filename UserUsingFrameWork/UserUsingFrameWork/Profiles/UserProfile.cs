﻿using AutoMapper;
using UserUsingFrameWork.Models;

namespace UserUsingFrameWork.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserVM>().ReverseMap();
            CreateMap<Post, PostVM>().ReverseMap();
            CreateMap<Post, PostVM>().ReverseMap();

        }
    }
}
