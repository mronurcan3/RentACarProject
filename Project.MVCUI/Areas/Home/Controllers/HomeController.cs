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
            List<Vehicle> allVehicles = _vehicle.Where(x => x.VehicleStatus == Entities.Enums.VehicleStatus.Available);

            Dictionary<string, int> myVehiclesUnits = new Dictionary<string, int>();

            foreach (Vehicle item in allVehicles )
            {
               



                if (myVehiclesUnits.ContainsKey(item.Brand))
                {
                    int a = myVehiclesUnits[item.Brand];

                    a++;

                    myVehiclesUnits[item.Brand] = a;

                    

                }

                else myVehiclesUnits.Add(item.Brand, 1);



            }

            Dictionary<string, int> myVehiclesUnits2 = new Dictionary<string, int>();

            foreach (Vehicle item in allVehicles)
            {




                if (myVehiclesUnits2.ContainsKey(item.Model))
                {
                    int a = myVehiclesUnits2[item.Model];

                    a++;

                    myVehiclesUnits2[item.Model] = a;



                }

                else myVehiclesUnits2.Add(item.Model, 1);



            }

            Dictionary<string, int> bodyTypes = new Dictionary<string, int>();

            foreach (Vehicle item in allVehicles)
            {




                if (bodyTypes.ContainsKey(item.Body.ToString()))
                {
                    int a = bodyTypes[item.Body.ToString()];

                    a++;

                    bodyTypes[item.Body.ToString()] = a;



                }

                else bodyTypes.Add(item.Body.ToString(), 1);



            }



            VehicleVM VVM = new VehicleVM()
            {
                Vehicles = _vehicle.Where(x => x.VehicleStatus == Entities.Enums.VehicleStatus.Available),
                VehiclesUnits = myVehiclesUnits,
                VehiclesUnits2 = myVehiclesUnits2,
                BodyTypes = bodyTypes,
            };
            return View(VVM);
        }


       public ActionResult Test()
       { 
            return View();
       }    

       
    }
}