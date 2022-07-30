using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace UserUsingFrameWork.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Handle
    {
        private readonly RequestDelegate _next;

        public Handle(RequestDelegate next)
        { 
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            { 
                  await _next(httpContext);
            }
            catch (Exception e)
            {
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "text/plain";  //for the message show in swagger it is not important when you use the postman 
                await httpContext.Response.WriteAsync(e.Message);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HandleExtensions
    { 
        public static IApplicationBuilder UseHandle(this IApplicationBuilder builder)
        { 
            return builder.UseMiddleware<Handle>();
        }
    }
}
