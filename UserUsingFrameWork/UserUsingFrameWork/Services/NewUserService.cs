﻿using AutoMapper;
using UserUsingFrameWork.Models;

namespace UserUsingFrameWork.Services
{

    public interface INewUserService : IGenRepo<User>
    {
    }
    public class NewUserService : GenRepo<User> , INewUserService
    {
        public NewUserService(UserContext context,IMapper mapper) : base(context ,mapper)
        {

        }
    }
}
