using Microsoft.EntityFrameworkCore;

namespace UserUsingFrameWork.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }
        DbSet<User> User
        {
            get;
            set;
        }
    }
}
