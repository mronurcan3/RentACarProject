using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Areas.Home.ModelVM
{
    public class UserVM
    {
        public AppUser User { get; set; }

        public List<AppUser> Users { get; set; }
    }
}