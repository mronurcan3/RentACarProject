using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Map.Options
{
    public class UserRentalMap:BaseMap<UserRental>
    {
        public UserRentalMap()
        {
            Ignore(x => x.ID).HasKey(x => new
            {

                x.RentalID,
                x.VehicleID,
            });
        }
    }
}
