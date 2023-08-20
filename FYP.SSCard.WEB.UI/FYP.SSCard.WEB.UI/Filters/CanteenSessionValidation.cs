using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FYP.SSCard.WEB.UI.Filters
{
    public class CanteenSessionValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            User user = (User)filterContext.HttpContext.Session[WebUtil.CURRENT_USER];

            if (user == null || user.Role.Id != (int)Roles.Cafeteria)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Users" },
                                { "Action", "Login" }
                                });
            }
        }
    }
}