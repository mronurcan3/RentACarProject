using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Vehicle:BaseEntity
    {

        public string PlateNumber { get; set; }

        public VehicleStatus VehicleStatus { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int KM { get; set; }

        public string Color { get; set; }

        public int EngineCapacity { get; set; }

        public int HP { get; set; }

        public int SeatCount { get; set; }

        public int Torque { get; set; }

        public int MinAge { get; set; }

        public int MinLisenceYear { get; set; }

        public FuelType Fuel { get; set; }

        public GearType Gear { get; set; }

        public BodyType Body { get; set; }

        //Relational Properties

        public virtual UserRental UserRental { get; set; }


    }
}
