﻿using AutoMapper;
using UserUsingFrameWork.Models;

namespace UserUsingFrameWork.Services
{

        public interface INewPostService : IGenRepo<Post>
        {
        }
        public class NewPostService : GenRepo<Post>, INewPostService
        {
            public NewPostService(UserContext context,IMapper mapper) : base(context,mapper)
            {
            }
        }
    }

