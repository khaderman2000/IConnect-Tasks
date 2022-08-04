using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UserUsingFrameWork.Models
{
    public class User :  IdentityUser<int> , IBasicModel
    {
       
        public string FirstName { get; set; }   
        public string LastName { get; set; } 
        public ICollection<Post>? Posts { get; set; }

    }


}
   

