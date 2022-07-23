using System.ComponentModel.DataAnnotations;

namespace UserUsingFrameWork.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
        public string FirstName { get; set; }   
        public string LastName { get; set; }

    }
}
