using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day1.Filters
{
    public class MyExceptionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ViewResult() { ViewName="Error" };
            }
            base.OnActionExecuted(context);
        }
    }
}
