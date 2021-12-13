using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Rental:BaseEntity
    {
        public int AppUserID { get; set; }

        public ReservationStatus ReservationStatus { get; set; }




        //Relational Properties

        public virtual List<AppUser> AppUsers { get; set; }
    }
}
