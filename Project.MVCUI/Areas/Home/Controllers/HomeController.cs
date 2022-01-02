using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Home
        public ActionResult Index()
        {
            return View();
        }


       public ActionResult Test()
       { 
            return View();
       }    

        public ActionResult Test2()
        {

            return View();
        }

        public ActionResult Test3()
        {
            return View();
        }
    }
}