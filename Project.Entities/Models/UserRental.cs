using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class UserRental:BaseEntity
    {

        public int RentalID { get; set; }

        public int VehicleID { get; set; }

        public DateTime RentalStart { get; set; }

        public DateTime? RentalEnd { get; set; }

        public RentalStatus RentalStatus { get; set; }

        public string PickUpLocation { get; set; }

        public string DropOffLocation { get; set; }




        //Relational Properties

        public virtual List<Rental> Rentals { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
