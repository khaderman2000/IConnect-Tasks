using Microsoft.AspNetCore.Mvc.Filters;

namespace UserUsingFrameWork.Fillters
{
    public class Roles :Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Role").Value != "Admin")
            {
                throw new Exception("you can't access to data");
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }




    }
}
