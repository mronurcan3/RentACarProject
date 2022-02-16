using Project.BLL.DesignPatterns.GenericRepository.ConRep;
using Project.MVCUI.Areas.Home.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entities.Models;
using Project.MVCUI.Tools;

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

        public ActionResult AddVehicle(VehicleVM vvm,string fuel,string trans,string bodyType, Image testClass, HttpPostedFileBase resim)
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
                    testClass.ImagePath = ImageUploader.UploadImage("/Images/", resim);
                    _image.Add(testClass);

                    vvm.Vehicle.Image = testClass;
                    vvm.Vehicle.VehicleStatus = Entities.Enums.VehicleStatus.Available;


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


        public ActionResult ListVehicle()
        {
            

            VehicleVM vvm = new VehicleVM()
            {
                Vehicles = _vehicle.GetActives
            (),
                
                
            };


            return View(vvm);

        }


        public ActionResult UpdateVehicle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult UpdateVehicle(string Price,string MinAge,string MinLisenceYear,string id)
        {

            try
            {

                bool myPrice = Convert.ToDecimal(Price) >= 1;

                bool myMinAge = Convert.ToInt32(MinAge) >= 0;

                bool MyMinLisenceYear = Convert.ToInt32(MinLisenceYear) >= 0;


                if (myPrice && myMinAge && MyMinLisenceYear)
                {


                    int myID = Convert.ToInt32(id);

                    Vehicle vehicle = _vehicle.FirstOrDefault(x => x.ID == myID);

                    vehicle.Price = Convert.ToDecimal(Price);
                    vehicle.MinAge = Convert.ToInt32(MinAge);
                    vehicle.MinLisenceYear = Convert.ToInt32(MinLisenceYear);

                    _vehicle.Update(vehicle);

                    TempData["result2"] = "car successfully updated";

                    return RedirectToAction("ListVehicle");
                }

                
            }

            catch (Exception ex)
            {
                string msg = ex.Message;
            }




           
                TempData["result2"] = "the car could not be updated please check that the values are in the correct format";
           


            return RedirectToAction("ListVehicle");
        }

        public ActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = _vehicle.FirstOrDefault(x => x.ID == id);

            if(vehicle.VehicleStatus == Entities.Enums.VehicleStatus.Available)
            {
                _vehicle.Delete(_vehicle.Find(id));

                TempData["result"] = "car deleted successfully";

            }

            TempData["result"] = "the car could not be deleted because its use";



            return RedirectToAction("ListVehicle");
        }
    }
}