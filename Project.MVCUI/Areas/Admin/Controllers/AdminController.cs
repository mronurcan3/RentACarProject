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

        [HttpPost]

        public ActionResult AddVehicle(VehicleVM vvm,string fuel,string trans,string bodyType)
        {
            switch (fuel)
            {
                case "Gas":
                    vvm.Vehicle.Fuel = Entities.Enums.FuelType.Gas;
                    break;
                case "Diesel":
                    vvm.Vehicle.Fuel = Entities.Enums.FuelType.Diesel;
                    break;
                case "Electric":
                    vvm.Vehicle.Fuel = Entities.Enums.FuelType.Electric;
                    break;
                case "Hybrid":
                    vvm.Vehicle.Fuel = Entities.Enums.FuelType.Hybrid;
                    break;
                default:
                    break;
            }

            switch (trans)
            {
                case "Automatic":
                    vvm.Vehicle.Gear = Entities.Enums.GearType.Automatic;
                    break;
                case "Manual":
                    vvm.Vehicle.Gear = Entities.Enums.GearType.Manual;
                    break;
                default:
                    break;
            }

            switch (bodyType)
            {
                case "Sedan":
                    vvm.Vehicle.Body = Entities.Enums.BodyType.Sedan;
                    break;
                case "Hatchback":
                    vvm.Vehicle.Body = Entities.Enums.BodyType.Hatchback;
                    break;
                case "SUV":
                    vvm.Vehicle.Body = Entities.Enums.BodyType.SUV;
                    break;
                case "Cabrio":
                    vvm.Vehicle.Body = Entities.Enums.BodyType.Cabrio;
                    break;
                case "Coupe":
                    vvm.Vehicle.Body = Entities.Enums.BodyType.Coupe;
                    break;
                case "Limousine":
                    vvm.Vehicle.Body = Entities.Enums.BodyType.Limousine;
                    break;
                case "Minivan":
                    vvm.Vehicle.Body = Entities.Enums.BodyType.Minivan;
                    break;

                default:
                    break;
            }


            if(vvm.Vehicle.Price != 0 && vvm.Vehicle.Fuel != 0 && vvm.Vehicle.SeatCount != 0 && vvm.Vehicle.Body != 0 && vvm.Vehicle.Brand != null && vvm.Vehicle.Color != null && vvm.Vehicle.EngineCapacity != 0 && vvm.Vehicle.Gear != 0 && vvm.Vehicle.HP != 0 && vvm.Vehicle.KM >= 0 && vvm.Vehicle.PlateNumber != null && vvm.Vehicle.MinAge >= 0 && vvm.Vehicle.MinLisenceYear >= 0 && vvm.Vehicle.Torque != 0 && vvm.Vehicle.Year != 0 && vvm.Vehicle.Model != null)
            {
                if(_vehicle.Any(x => x.PlateNumber != vvm.Vehicle.PlateNumber))
                {
                    _vehicle.Add(vvm.Vehicle);

                    TempData["result"] = "car successfully added";

                    return View();

                }

                else
                {
                    TempData["result"] = "There is another vehicle registered to this plate";
                }


                

            }

            TempData["result"] = "Make sure that the entered values are in the correct format.";







            return View();
        }
    }
}