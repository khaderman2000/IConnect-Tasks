using Microsoft.EntityFrameworkCore;
using UserUsingFrameWork.Models;
using UserUsingFrameWork.Services;
using UserUsingFrameWork.Fillters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UserUsingFrameWork.Extensions
{
    public static class MainExtension
    {
        public static void Start(this IServiceCollection services, ConfigurationManager conf)
        {
            var connectionString = conf.GetConnectionString("ConStr");
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<User, UserRoles>()
            .AddEntityFrameworkStores<UserContext>()
            
            .AddDefaultTokenProviders();
            services.Configure<JWT>(conf.GetSection("JWT"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = conf["JWT:Audience"],
                    ValidIssuer = conf["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["JWT:Secret"]))
                };
            });

            services.AddScoped<INewUserService, NewUserService>();
            services.AddScoped<INewPostService, NewPostService>();
            services.AddScoped<Roles>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
