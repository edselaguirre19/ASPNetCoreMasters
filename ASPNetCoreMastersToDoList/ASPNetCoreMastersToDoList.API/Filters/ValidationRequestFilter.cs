using ASPNetCoreMastersToDoList.Repository;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreMastersToDoList.API.Filters
{
    public class ValidationRequestFilter: ActionFilterAttribute
    {
        private readonly DataContext _dataContext;
        public ValidationRequestFilter(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var id = filterContext.RouteData.Values["id"];
            if (id != null)
            {
                var check = _dataContext.Items.Any(x => x.Id == Convert.ToInt16(id));
                if (!check)
                {
                    filterContext.Result = new NotFoundResult();
                }
            }

            
        }
    }
}
