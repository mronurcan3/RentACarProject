using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Image:BaseEntity
    {
        //asdasd
        public string Name { get; set; }

        public string ImagePath { get; set; }

        //Relational Properties
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
