using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Net;

namespace ASPNetCoreMastersToDoList.API.Filters
{
    public class GlobalPerfomanceFilter : ActionFilterAttribute
    {
        Stopwatch stopWatch;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public override void OnResultExecuted(ResultExecutedContext resultContext)
        {
            stopWatch.Stop();
            var controllerName = resultContext.RouteData.Values["controller"];
            var actionName = resultContext.RouteData.Values["action"];
            Debug.WriteLine($"Time Elapse for /{controllerName}/{actionName}: {stopWatch.ElapsedMilliseconds}ms");

            var result = (OkObjectResult)resultContext.Result;

            if(result.Value == null)
            {
                resultContext.HttpContext.Response.StatusCode = 404;
            }
        }
    }
}
