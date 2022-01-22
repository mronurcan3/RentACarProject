using Project.DAL.Context;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            
            UserProfile userProfile1 = new UserProfile()
            {
                FirstName = "alisya",
                LastName = "yildirim",
                Email = "alisyayildirim@gmail.com",
                BirthDay = DateTime.Now,
                IdentificationNumber = "12345678912",
                LisenceNumber = "123456789",
                Balance = 500,
               
                




            };

            AppUser appUser1 = new AppUser()
            {
                UserName = "alisyay",
                Password = "123",
                Role = Entities.Enums.UserRole.Member,
                UserProfile = userProfile1,



            };

            context.AppUsers.Add(appUser1);
            context.UserProfiles.Add(userProfile1);

            UserProfile userProfile2 = new UserProfile()
            {
                FirstName = "mehmet",
                LastName = "yildirim",
                Email = "mehmetyildirim@gmail.com",
                BirthDay = DateTime.Now,
                IdentificationNumber = "12345678921",
                LisenceNumber = "123456788",
                Balance = 500,
               




            };

            AppUser appUser2 = new AppUser()
            {
                UserName = "mehmety",
                Password = "123",
                Role = Entities.Enums.UserRole.Member,
                UserProfile = userProfile2,



            };
            context.AppUsers.Add(appUser2);
            context.UserProfiles.Add(userProfile2);

            UserProfile userProfile3 = new UserProfile()
            {
                FirstName = "ali",
                LastName = "yildirim",
                Email = "aliyildirim@gmail.com",
                BirthDay = DateTime.Now,
                IdentificationNumber = "12345678922",
                LisenceNumber = "123456778",
                Balance = 500,
                





            };

            AppUser appUser3 = new AppUser()
            {
                UserName = "aliy",
                Password = "123",
                Role = Entities.Enums.UserRole.Member,
                UserProfile = userProfile3,



            };

            context.AppUsers.Add(appUser3);
            context.UserProfiles.Add(userProfile3);

            UserProfile userProfile4 = new UserProfile()
            {
                FirstName = "onurcan",
                LastName = "yildirim",
                Email = "onurcanyildirim@gmail.com",
                BirthDay = DateTime.Now,
                IdentificationNumber = "12345678925",
                LisenceNumber = "123456779",
                Balance = 500,





            };

            AppUser appUser4 = new AppUser()
            {
                UserName = "onurcany",
                Password = "123",
                Role = Entities.Enums.UserRole.Admin,
                UserProfile = userProfile4,



            };

            context.AppUsers.Add(appUser4);
            

            Vehicle vehicle1 = new Vehicle()
            {
                PlateNumber = "35umc62",
                VehicleStatus = Entities.Enums.VehicleStatus.Available,
                Brand = "Mercedes",
                Model = "C200",
                Year = 2018,
                KM = 25000,
                Color = "Blue",
                EngineCapacity = 2000,
                HP = 245,
                SeatCount = 5,
                Torque = 400,
                MinAge = 21,
                MinLisenceYear = 3,
                Fuel = Entities.Enums.FuelType.Gas,
                Gear = Entities.Enums.GearType.Automatic,
                Body = Entities.Enums.BodyType.Sedan,
                Price = 100m,




            };

            context.Vehicles.Add(vehicle1);
            
            Vehicle vehicle2 = new Vehicle()
            {
                PlateNumber = "35uml62",
                VehicleStatus = Entities.Enums.VehicleStatus.Available,
                Brand = "Mercedes",
                Model = "R3",
                Year = 2015,
                KM = 25000,
                Color = "Yellow",
                EngineCapacity = 4000,
                HP = 565,
                SeatCount = 2,
                Torque = 700,
                MinAge = 25,
                MinLisenceYear = 7,
                Fuel = Entities.Enums.FuelType.Gas,
                Gear = Entities.Enums.GearType.Automatic,
                Body = Entities.Enums.BodyType.Sedan,
                Price = 300m,




            };

            context.Vehicles.Add(vehicle2);

            Vehicle vehicle3 = new Vehicle()
            {
                PlateNumber = "35uma62",
                VehicleStatus = Entities.Enums.VehicleStatus.Available,
                Brand = "BMW",
                Model = "X5",
                Year = 2014,
                KM = 25000,
                Color = "White",
                EngineCapacity = 3000,
                HP = 350,
                SeatCount = 5,
                Torque = 500,
                MinAge = 25,
                MinLisenceYear = 7,
                Fuel = Entities.Enums.FuelType.Gas,
                Gear = Entities.Enums.GearType.Automatic,
                Body = Entities.Enums.BodyType.Sedan,
                Price = 200m,




            };

            context.Vehicles.Add(vehicle3);

            Vehicle vehicle4 = new Vehicle()
            {
                PlateNumber = "35umr62",
                VehicleStatus = Entities.Enums.VehicleStatus.Available,
                Brand = "Audi",
                Model = "R8",
                Year = 2013,
                KM = 25000,
                Color = "Black",
                EngineCapacity = 4000,
                HP = 625,
                SeatCount = 2,
                Torque = 750,
                MinAge = 25,
                MinLisenceYear = 7,
                Fuel = Entities.Enums.FuelType.Gas,
                Gear = Entities.Enums.GearType.Automatic,
                Body = Entities.Enums.BodyType.Sedan,
                Price = 400m,




            };

            context.Vehicles.Add(vehicle4);

            Vehicle vehicle5 = new Vehicle()
            {
                PlateNumber = "35umk62",
                VehicleStatus = Entities.Enums.VehicleStatus.Available,
                Brand = "Audi",
                Model = "Q3",
                Year = 2016,
                KM = 25000,
                Color = "Orange",
                EngineCapacity = 1600,
                HP = 150,
                SeatCount = 4,
                Torque = 320,
                MinAge = 23,
                MinLisenceYear = 5,
                Fuel = Entities.Enums.FuelType.Gas,
                Gear = Entities.Enums.GearType.Automatic,
                Body = Entities.Enums.BodyType.Sedan,
                Price = 90m,




            };

            context.Vehicles.Add(vehicle5);

            Vehicle vehicle6 = new Vehicle()
            {
                PlateNumber = "35uhl62",
                VehicleStatus = Entities.Enums.VehicleStatus.Available,
                Brand = "Audi",
                Model = "R8",
                Year = 2017,
                KM = 25000,
                Color = "White",
                EngineCapacity = 4000,
                HP = 565,
                SeatCount = 2,
                Torque = 700,
                MinAge = 25,
                MinLisenceYear = 7,
                Fuel = Entities.Enums.FuelType.Gas,
                Gear = Entities.Enums.GearType.Automatic,
                Body = Entities.Enums.BodyType.Sedan,
                Price = 370m,




            };

            context.Vehicles.Add(vehicle6);
            


            context.SaveChanges();


        }

    }
}
