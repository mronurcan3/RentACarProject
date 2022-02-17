using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.AuthenticationClasses
{
    public class AdminAuthentication : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["admin"] != null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Admin/Admin/AdminLogin"); //sakın buradaki URL paterninin basına slash koymayı unutmayın yoksa gider normal paternin üzerinde bir daha Home/Login yazar...
            return false;
        }
    }
}