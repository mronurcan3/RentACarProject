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
    }
}