namespace UserUsingFrameWork.Fillters
{
    public class Roles : Attribute
    {
        public  Roles (HttpContext httpcontext)
        {
            Console.WriteLine(httpcontext.Request.Headers);

        }


    }
}
