using Project.BLL.DesignPatterns.GenericRepository.ConRep;
using Project.Common;
using Project.Entities.Models;
using Project.MVCUI.Areas.Home.ConsumerDTO;
using Project.MVCUI.Areas.Home.ModelVM;
using Project.MVCUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        VehicleRepository _vehicle;
        ImageRepository _image;
        AppUserRepository _appUser;
        UserProfileRepository _profile;
        RentalRepository _rental;
        UserRentalRepository _userRental;

        


        public HomeController()
        {
           _vehicle = new VehicleRepository();
            _image = new ImageRepository();
            _appUser = new AppUserRepository();
            _profile = new UserProfileRepository();
            _rental = new RentalRepository();

            _userRental = new UserRentalRepository();
        }

        // GET: Home/Home
        public ActionResult Index()
        {


            if(Session["user"] != null)
            {
                string ids = Session["user"].ToString();

                int id = Convert.ToInt32(ids);

                List<AppUser> appUser = new List<AppUser>();

                appUser.Add(_appUser.FirstOrDefault(x => x.ID == id));

                VehicleVM UVM = new VehicleVM()
                {
                    Users = appUser,
                };

                return View(UVM);
            }

            VehicleVM vvm = new VehicleVM()
            {
                Users = _appUser.GetActives(),
            };

            return View(vvm);
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

            List<AppUser> appUser = new List<AppUser>();

            if (Session["user"] != null)
            {
                int id = Convert.ToInt32(Session["user"]);

               

                appUser.Add(_appUser.FirstOrDefault(x => x.ID == id));



            }

            else
            {
                appUser.AddRange(_appUser.GetAll());
            }


            VehicleVM VVM = new VehicleVM()
            {
                Vehicles = _vehicle.Where(x => x.VehicleStatus == Entities.Enums.VehicleStatus.Available),
                VehiclesUnits = myVehiclesUnits,
                VehiclesUnits2 = myVehiclesUnits2,
                BodyTypes = bodyTypes,
                Users = appUser,

            };
            return View(VVM);
        }

        [HttpPost]

        public ActionResult Rental(string PickUp)
        {
             

            return RedirectToAction("GetFilterCars");
        }






       

        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index2(Image testClass, HttpPostedFileBase resim)
        {
            testClass.ImagePath = ImageUploader.UploadImage("/Images/", resim);
           _image.Add(testClass);
            
            return RedirectToAction("Index2");
        }

        public PartialViewResult GetSearchCars(DateTime pickUpDate, DateTime dropOffDate)
        {
            

           

            VehicleVM VVM = new VehicleVM()
            {
                Vehicles = _vehicle.Where(x => x.VehicleStatus == Entities.Enums.VehicleStatus.Available),

                
            };

            return PartialView("_RentalCars", VVM);
        }

        public PartialViewResult GetFilterCars(string filter,string typ)
        {

            switch (typ)
            {
                case "type":
                    switch (filter)
                    {
                        case "Sedan":
                            VehicleVM VVMx = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Body == Entities.Enums.BodyType.Sedan && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVMx);

                        case "Hatchback":
                            VehicleVM VVM22 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Body == Entities.Enums.BodyType.Hatchback && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM22);

                        case "SUV":
                            VehicleVM VVM33 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Body == Entities.Enums.BodyType.SUV && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM33);

                        case "Cabrio":
                            VehicleVM VVM4 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Body == Entities.Enums.BodyType.Cabrio && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM4);

                        case "Coupe":
                            VehicleVM VVM5 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Body == Entities.Enums.BodyType.Coupe && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM5);

                        case "Limousine":
                            VehicleVM VVM6 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Body == Entities.Enums.BodyType.Limousine && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM6);

                        case "Minivan":
                            VehicleVM VVM7 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Body == Entities.Enums.BodyType.Minivan && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM7);

                        default:
                            VehicleVM VVM8 = new VehicleVM()
                            {
                                Vehicles = _vehicle.GetActives(),


                            };

                            return PartialView("_RentalCars", VVM8);

                    }

                case "model":
                    VehicleVM VVM = new VehicleVM()
                    {
                        Vehicles = _vehicle.Where(x => x.Model == filter && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                    };

                    return PartialView("_RentalCars", VVM);

                case "priceRange":
                    switch (filter)
                    {
                        case "0-500":

                            VehicleVM VVM1 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Price <= 500 && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM1);

                        case "500-1000":

                            VehicleVM VVM22 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Price > 500 && x.Price <= 1000 && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM22);

                        case "1000-2000":

                            VehicleVM VVM33 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Price > 1000 && x.Price <= 2000 && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM33);

                        case "2500":

                            VehicleVM VVM4 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Price >= 2500 && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM4);

                        default:

                            VehicleVM VVM5 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Price >= 0 && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM5);



                    }


                case "fuel":
                    switch (filter)
                    {
                        case "Gas":

                            VehicleVM VVM22 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Fuel == Entities.Enums.FuelType.Gas && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM22);

                        case "Diesel":

                            VehicleVM VVM33 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Fuel == Entities.Enums.FuelType.Diesel && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM33);

                        case "Electric":

                            VehicleVM VVM4 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Fuel == Entities.Enums.FuelType.Electric && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM4);

                        case "Hybrid":

                            VehicleVM VVM5 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Fuel == Entities.Enums.FuelType.Hybrid && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM5);

                        default:
                            VehicleVM VVM6 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Fuel == Entities.Enums.FuelType.Gas && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM6);


                    }


                case "transmission":
                    switch (filter)
                    {
                        case "Automatic":
                            VehicleVM VVM22 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Gear == Entities.Enums.GearType.Automatic && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM22);

                        case "Manuel":
                            VehicleVM VVM33 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Gear == Entities.Enums.GearType.Manual && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM33);

                        default:

                            VehicleVM VVM4 = new VehicleVM()
                            {
                                Vehicles = _vehicle.Where(x => x.Gear == Entities.Enums.GearType.Automatic && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                            };

                            return PartialView("_RentalCars", VVM4);


                    }

                case "brand":
                    VehicleVM VVM2 = new VehicleVM()
                    {
                        Vehicles = _vehicle.Where(x => x.Brand == filter && x.VehicleStatus == Entities.Enums.VehicleStatus.Available),


                    };

                    return PartialView("_RentalCars", VVM2);



                default:
                    VehicleVM VVM3 = new VehicleVM()
                    {
                        Vehicles = _vehicle.GetActives(),


                    };

                    return PartialView("_RentalCars", VVM3);

                    
            }



            
        }



        public ActionResult Payment(int id)
        {
            List<AppUser> appUser = new List<AppUser>();

            if (Session["user"] != null)
            {
                int myid = Convert.ToInt32(Session["user"]);



                appUser.Add(_appUser.FirstOrDefault(x => x.ID == myid));



            }

            else
            {
                appUser.AddRange(_appUser.GetAll());
            }

            VehicleVM VVM = new VehicleVM()
            {
                Vehicles = _vehicle.Where(x => x.ID == id),
                Users = appUser,
            };


            return View(VVM);
        }

        public PartialViewResult GetRentCar(DateTime pickUpDate, DateTime dropOffDate,int id)
        {
            int day = (dropOffDate - pickUpDate).Days;

            List<DateTime> myDates = new List<DateTime>();

            myDates.Add(pickUpDate);
            myDates.Add(dropOffDate);

            VehicleVM VVM = new VehicleVM()
            {
                Date = day,
                Vehicles = _vehicle.Where(x => x.ID == id),
                Dates = myDates,

                
            };


            return PartialView("_Rent", VVM);


        }



        public ActionResult SignUp()
        {
            UserVM UserVM = new UserVM()
            {

            };

            return View(UserVM);
        }

        [HttpPost]

        public ActionResult SignUp(string userName, string password,string firstName,string lastName, string email, DateTime birthday, string idNumber, string lisenceNumber)
        {

            

            if(_appUser.Any(x => x.UserName == userName))
            {
                ViewBag.ZatenVar = "Kullanıcı ismi daha önce alınmıs";
                return View();



            }

            else if (_profile.Any(x => x.Email == email))
            {
                ViewBag.ZatenVar = "Email zaten kayıtlı";
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
                Role = Entities.Enums.UserRole.Visitor,
                UserProfile = userProfile,
            };

            _appUser.Add(appUser);

            string emailWillSend = "Congratulations, your account has been successfully created. To activate your account https://localhost:44330/Home/Home/Activation/" + appUser.ActivationCode + " you can click the link";

            MailService.Send(appUser.UserProfile.Email, body: emailWillSend, subject: "Hesap aktivasyon!!!");
             //öncelikle bunu eklemelisiniz...Cünkü AppUser'in ID'si ilk basta olusmalı...Cünkü bizim kurdugumuz birebir ilişkide AppUser zorunlu alan Profile ise opsiyonel alandır...Dolayısıyla ilk basta AppUser'in ID'si SaveChanges ile olusmalı ki sonra Profile'i rahatca ekleyebilelim...
                  
            return RedirectToAction("EmailConfirm", "Home");
        }

        public ActionResult Activation(Guid id)
        {
            AppUser willactive = _appUser.FirstOrDefault(x => x.ActivationCode == id);
            if (willactive != null)
            {
                willactive.Role = Entities.Enums.UserRole.Member;
                _appUser.Update(willactive);
                TempData["isAccountActive"] = "Your e-mail has been successfully confirmed";
                return RedirectToAction("EmailConfirm", "Home");
            }
            TempData["isAccountActive"] = "Could not found any account";
            return RedirectToAction("EmailConfirm", "Home");
        }



        public ActionResult EmailConfirm()
        {
            return View();

        }


        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SingIn(string userName,string password)
        {
            if(_appUser.Any(x => x.UserName == userName && x.Password == password))
            {

                AppUser user = _appUser.FirstOrDefault(x => x.UserName == userName && x.Password == password);

                Session["user"] = user.ID;
            }



            return RedirectToAction("Index");
        }

        public ActionResult AcountInfo()
        {
            if(Session["user"] != null)
            {
                int confrim = 0;

                List<Vehicle> vehicle = new List<Vehicle>();

                int id = Convert.ToInt32(Session["user"]);

                List<AppUser> appUser = new List<AppUser>();

                appUser.Add(_appUser.FirstOrDefault(x => x.ID == id));

                int appuserID = appUser[0].ID;

                if (_rental.Any(x => x.AppUserID == appuserID))
                {
                    List<Vehicle> vehicles = new List<Vehicle>();

                    List<Rental> myRental = _rental.GetActives();

                    List<int> myRentalID = new List<int>();

                   foreach(Rental item in myRental)
                    {
                        if(item.AppUserID == appUser[0].ID)
                        {
                            myRentalID.Add(item.ID);
                        }
                        
                        

                    }

                    List<UserRental> userRental = _userRental.GetActives();

                    List<int> userRentalID = new List<int>();

                    foreach (UserRental item in userRental)
                    {
                        foreach (int s in myRentalID)
                        {
                            if(item.RentalID == s)
                            {
                                userRentalID.Add(item.VehicleID);
                            }

                        }

                       



                    }


                   




                    foreach (int item in userRentalID)
                    {
                       
                        
                           
                            
                                vehicle.Add(_vehicle.FirstOrDefault(x => x.ID == item));


                        confrim = 1;
                        

                    }





                }

                VehicleVM VVM = new VehicleVM()
                {
                    Users = appUser,
                    Vehicles = vehicle,
                    Confirm = confrim,
                };

                return View(VVM);
            }

            return RedirectToAction("Index");


        }


        [HttpPost]

        public ActionResult AcountInfo(string cardUserName, string securityNumber, string cardNumber, string cardExpiryMonth, string cardExpiryYear, string shoppingPrice,string userID)
        {

            List<AppUser> myAppUser = new List<AppUser>();

            PaymentDTO PDTO = new PaymentDTO()
            {
                CardUserName = cardUserName,
                SecurityNumber = securityNumber,
                CardNumber = cardNumber,
                CardExpiryMonth = Convert.ToInt32(cardExpiryMonth),
                CardExpiryYear = Convert.ToInt32(cardExpiryYear),
                ShoppingPrice = Convert.ToDecimal(shoppingPrice),


            };


            bool result;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/api/");

                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Payment/ReceivePayment", PDTO);

                HttpResponseMessage sonuc;

                try
                {
                   sonuc = postTask.Result;
                }

                catch (Exception ex)
                {

                    TempData["ConfirmStatus"] = "The transaction was rejected by your bank";

                    return View();
                }

                if (sonuc.IsSuccessStatusCode) result = true;

                else result = false;

                if (result)
                {
                    int id = Convert.ToInt32(userID);

                    AppUser appUser = _appUser.FirstOrDefault(x => x.ID == id);

                    appUser.UserProfile.Balance += Convert.ToDecimal(shoppingPrice);

                    _appUser.Update(appUser);

                    TempData["ConfirmStatus"] = $"The {shoppingPrice}$ transaction has been confirmed by your bank.";

                    myAppUser.Add(appUser);

                }





            }



            VehicleVM VVM = new VehicleVM()
            {
                Users = myAppUser,
            };





            return View(VVM);

        }

            
        public ActionResult FinalRent()
        {

            return View();
        }
        [HttpPost]

        public ActionResult FinalRent(string finalPayment)
        {
            
            string[] inf = finalPayment.Split(',');

            int userID = Convert.ToInt32(inf[2]);

            AppUser user = _appUser.FirstOrDefault(x => x.ID == userID);

            if (user.UserProfile.Balance >= Convert.ToDecimal(inf[4]))
            {



                user.UserProfile.Balance -= Convert.ToDecimal(inf[4]);

                _appUser.Update(user);

                Rental rent = new Rental
                {
                    AppUserID = Convert.ToInt32(inf[2]),

                    ReservationStatus = Entities.Enums.ReservationStatus.Start,
                };

                _rental.Add(rent);

                int rentalID = _rental.FirstOrDefault(x => x.ID == rent.ID).ID;

                UserRental userRental = new UserRental()
                {
                    RentalID = rentalID,
                    VehicleID = Convert.ToInt32(inf[3]),
                    RentalStart = Convert.ToDateTime(inf[0]),
                    RentalEnd = Convert.ToDateTime(inf[1]),
                    RentalStatus = Entities.Enums.RentalStatus.RentalOn,
                };

                _userRental.Add(userRental);

                int vehicleID = Convert.ToInt32(inf[3]);

                Vehicle vehicle = _vehicle.FirstOrDefault(x => x.ID == vehicleID);

                vehicle.UserRentalID = userID;
                vehicle.UserRentalName = _appUser.FirstOrDefault(x => x.ID == userID).UserName;

                vehicle.VehicleStatus = Entities.Enums.VehicleStatus.OnRent;

                _vehicle.Update(vehicle);

                TempData["result"] = "car successfully rented";

                return RedirectToAction("FinalPaymentConfirm");



            }

            TempData["result"] = "car could not rent";



            return RedirectToAction("AcountInfo");





        }


       

        
        








    }
}