using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IT_Center_Website.Filters
{
    public class AdminAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.HttpContext.Session.GetInt32("RoleId") != 1)
            {
                context.Result = new UnauthorizedResult();
            }
            else
                base.OnResultExecuting(context);

        }
    }
}
