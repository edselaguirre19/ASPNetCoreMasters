using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNetCoreMastersToDoList.API.Filters
{
    public class ValidationRequestFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var id = filterContext.RouteData.Values["id"];
            if (id == null) return;
        }
    }
}
