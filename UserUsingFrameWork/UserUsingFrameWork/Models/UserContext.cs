using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserUsingFrameWork.Models
{
    public class UserContext : IdentityDbContext<User, UserRoles, int>
    { 
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
      
        DbSet<User> User
        {
            get;
            set;
        }
        DbSet<Post> Post
        {
            get;
            set;
        }

    }
}
