using Project.BLL.DesignPatterns.GenericRepository.ConRep;
using Project.Entities.Models;
using Project.MVCUI.Areas.Home.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        VehicleRepository _vehicle;
        public HomeController()
        {
           _vehicle = new VehicleRepository();
        }

        // GET: Home/Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(DateTime date1,DateTime date2)
        {
            return View();
        }


        public ActionResult Rental()
        {
            VehicleVM VVM = new VehicleVM()
            {
                Vehicles = _vehicle.Where(x => x.VehicleStatus == Entities.Enums.VehicleStatus.Available)
            };
            return View(VVM);
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

        public ActionResult Test4()
        {
            VehicleVM vvm = new VehicleVM()
            {
                Vehicle = new Vehicle
                {
                    Body = Entities.Enums.BodyType.Sedan,
                    Brand = "Mercedes",
                    Color = "Red",
                    CreatedDate = DateTime.Now,
                    EngineCapacity = 2000,
                    Fuel = Entities.Enums.FuelType.Gas,
                    Gear = Entities.Enums.GearType.Automatic,
                    HP = 245,
                    Torque = 360,
                    KM = 2000,
                    PlateNumber = "35url35",
                    VehicleStatus = Entities.Enums.VehicleStatus.Available,
                    Model = "c200",
                    Year = 2019,
                    SeatCount = 4,
                    MinAge = 22,
                    MinLisenceYear = 3,
                    Status = Entities.Enums.DataStatus.Inserted,
                    ID = 1,

                },
            };

            return View(vvm);
        }

        [HttpPost]

        public ActionResult Test4(DateTime mydata)
        {
            DateTime ss = mydata;

            return View();
        }
    }
}