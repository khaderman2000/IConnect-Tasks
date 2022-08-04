using Microsoft.AspNetCore.Identity;

namespace UserUsingFrameWork.Models
{
    public class UserRoles : IdentityRole<int>
    {
        
            public const string Admin = "Admin";
            public const string User = "User";
        
    }
}
