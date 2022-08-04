using System.ComponentModel.DataAnnotations;

namespace UserUsingFrameWork.Models
{
    public class UserVM:BasicModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

    }
}
