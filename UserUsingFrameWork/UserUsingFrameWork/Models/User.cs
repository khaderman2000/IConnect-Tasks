using System.ComponentModel.DataAnnotations;

namespace UserUsingFrameWork.Models
{
    public class User: BasicModel
    {
       
        public string FirstName { get; set; }   
        public string LastName { get; set; }

        public ICollection<Post>? Posts { get; set; }


    }
}
