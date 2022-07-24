using UserUsingFrameWork.Models;
using UserUsingFrameWork.ViewModels;

namespace UserUsingFrameWork.Services
{
    public class UserService : IUserService
    {
        private UserContext _context;
        public UserService(UserContext context)
        {
            _context = context;
        }

        public ResponseModel AddUser(User userModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                _context.Add<User>(userModel);
                model.Messsage = "User Inserted Successfully";
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

        public ResponseModel DeleteUser(int userId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = GetUserDetailsById(userId);
                if (_temp != null)
                {
                    _context.Remove<User>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "User Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public User GetUserDetailsById(int userId)
        {
            User user;
            try
            {
                user = _context.Find<User>(userId);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public List<User> GetUsersList()
        {
            List<User> userList;
            try
            {
                userList = _context.Set<User>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }

        public ResponseModel SaveUser(User userModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = GetUserDetailsById(userModel.Id);
                if (_temp != null)
                {
                    _temp.FirstName = userModel.FirstName;
                    _temp.LastName = userModel.LastName;
                    
                    _context.Update<User>(_temp);
                    model.Messsage = "User Update Successfully";
                }
                else
                {
                    _context.Add<User>(userModel);
                    model.Messsage = "User Inserted Successfully";
                }
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

        public ResponseModel UpdateUser(User userModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = GetUserDetailsById(userModel.Id);
                if (_temp != null)
                {
                    _temp.FirstName = userModel.FirstName;
                    _temp.LastName = userModel.LastName;

                    _context.Update<User>(_temp);
                    model.Messsage = "User Update Successfully";
                    _context.SaveChanges();
                    model.IsSuccess = true;
                }
                else
                {
                    
                    model.Messsage = "Can't find the User";
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
