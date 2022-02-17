using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Areas.Home.ModelVM
{
    public class VehicleVM
    {
        public Vehicle Vehicle { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public Dictionary<string,int> VehiclesUnits { get; set; }

        public Dictionary<string, int> VehiclesUnits2 { get; set; }

        public Dictionary<string, int> BodyTypes { get; set; }

        public List<Image> Images { get; set; }

        public Image Image { get; set; }

        public int Date { get; set; }

        public List<DateTime> Dates { get; set; }

        public List<AppUser> Users { get; set; }

        public int Confirm { get; set; }
    }

}