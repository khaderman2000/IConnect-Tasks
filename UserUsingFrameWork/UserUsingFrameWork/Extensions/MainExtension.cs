using Microsoft.EntityFrameworkCore;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;
using UserUsingFrameWork.Fillters;

namespace UserUsingFrameWork.Extensions
{
    public static  class MainExtension
    {
        public static void Start(this IServiceCollection services, ConfigurationManager conf)
        {
            var connectionString = conf.GetConnectionString("ConStr");
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
            //builder.Services.AddDbContext<PostContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<INewUserService, NewUserService>();
            services.AddScoped<INewPostService, NewPostService>();
            services.AddScoped<Roles>();



        }
    }
}
