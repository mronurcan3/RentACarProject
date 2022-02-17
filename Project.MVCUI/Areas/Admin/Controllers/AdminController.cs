using Project.BLL.DesignPatterns.GenericRepository.ConRep;
using Project.MVCUI.Areas.Home.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entities.Models;
using Project.MVCUI.Tools;
using Project.MVCUI.Areas.Admin.AuthenticationClasses;

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

        
        public ActionResult AdminLogin()
        {
            Session.Remove("admin");


            return View();
        }

        [HttpPost]

        public ActionResult AdminLogin(string adminName, string password)
        {
            if(_appUser.Any(x => x.UserName == adminName && x.Password == password && x.Role == Entities.Enums.UserRole.Admin))
            {

                AppUser user = _appUser.FirstOrDefault(x => x.UserName == adminName && x.Password == password && x.Role == Entities.Enums.UserRole.Admin );

                Session["admin"] = user.ID;

                return RedirectToAction("ListVehicle");


            }

            TempData["result"] = "There is no admin match";

            return View();

            
        }

        [AdminAuthentication]
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

        [AdminAuthentication]
        public ActionResult ListVehicle()
        {
            List<AppUser> appUser = new List<AppUser>();

            int id = Convert.ToInt32(Session["admin"]);

            appUser.Add(_appUser.FirstOrDefault(x => x.ID == id));

            VehicleVM vvm = new VehicleVM()
            {
                Vehicles = _vehicle.GetActives
            (),

                Users = appUser,
                
                
            };


            return View(vvm);

        }

        [AdminAuthentication]
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
        [AdminAuthentication]
        public ActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = _vehicle.FirstOrDefault(x => x.ID == id);

            if(vehicle.VehicleStatus == Entities.Enums.VehicleStatus.Available)
            {
                _vehicle.Delete(_vehicle.Find(id));

                TempData["myresult"] = "car deleted successfully";

            }

            TempData["myresult"] = "the car could not be deleted because its use";



            return RedirectToAction("ListVehicle");
        }

        [AdminAuthentication]

        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddAdmin(string userName, string password, string firstName, string lastName, string email, DateTime birthday, string idNumber, string lisenceNumber)
        {
            if (_appUser.Any(x => x.UserName == userName))
            {
                TempData["AlreadyHave"] = "username already taken";
                return View();



            }

            else if (_profile.Any(x => x.Email == email))
            {
                TempData["AlreadyHave"] = "Email already taken";
                return View();
            }



            UserProfile userProfile = new UserProfile()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                BirthDay = birthday,
                IdentificationNumber = idNumber,
                LisenceNumber = lisenceNumber,


            };

            AppUser appUser = new AppUser()
            {
                UserName = userName,
                Password = password,
                Role = Entities.Enums.UserRole.Admin,
                UserProfile = userProfile,
            };

            _appUser.Add(appUser);

            TempData["AlreadyHave"] = "Registration Successful";

            return View();
        }

        [AdminAuthentication]
        public ActionResult ListAdmin()
        {
            UserVM userVM = new UserVM()
            {
                Users = _appUser.Where(x => x.Role == Entities.Enums.UserRole.Admin && x.Status != Entities.Enums.DataStatus.Deleted),
            };


            return View(userVM);
        }
        [AdminAuthentication]
        public ActionResult UpdateAdmin(int id)
        {
            UserVM UVM = new UserVM()
            {
                User = _appUser.Find(id)
            };


            return View(UVM);
        }

        [HttpPost]

        public ActionResult UpdateAdmin(AppUser user)
        {

            user.Role = Entities.Enums.UserRole.Admin;
            
            _appUser.Update(user);


            return RedirectToAction("ListAdmin");
        }





        [AdminAuthentication]
        public ActionResult DeleteAdmin(int id)
        {
            _appUser.Delete(_appUser.Find(id));

            return RedirectToAction("ListAdmin");
        }
    }
}