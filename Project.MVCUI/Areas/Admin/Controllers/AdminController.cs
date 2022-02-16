using Project.BLL.DesignPatterns.GenericRepository.ConRep;
using Project.MVCUI.Areas.Home.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{




    public class AdminController : Controller
    {
        VehicleRepository _vehicle;
        ImageRepository _image;
        AppUserRepository _appUser;
        UserProfileRepository _profile;
        RentalRepository _rental;
        UserRentalRepository _userRental;




        public AdminController()
        {
            _vehicle = new VehicleRepository();
            _image = new ImageRepository();
            _appUser = new AppUserRepository();
            _profile = new UserProfileRepository();
            _rental = new RentalRepository();

            _userRental = new UserRentalRepository();
        }





        // GET: Admin/Admin
        public ActionResult AddVehicle()
        {
            

            return View();
        }
    }
}