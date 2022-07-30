﻿using UserUsingFrameWork.Models;
using UserUsingFrameWork.ViewModels;

namespace UserUsingFrameWork.Services
{
    public interface IUserService
    {
        
        List<User> GetUsersList();

        User GetUserDetailsById(int userId);

        ResponseModel SaveUser(User userModel);

        ResponseModel AddUser(User userModel);
        ResponseModel UpdateUser(User userModel);

        ResponseModel DeleteUser(int userId);
    }
}
