using Microsoft.AspNetCore.Mvc.Filters;

namespace UserUsingFrameWork.Fillters
{
    public class Roles :Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Role").Value != "khader")
            {
                throw new Exception("can't access");
                return ;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }




    }
}
