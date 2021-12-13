using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class UserProfile:BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDay { get; set; }

        public string IdentificationNumber { get; set; }

        public string LisenceNumber { get; set; }

        public decimal Balance { get; set; }

        //Relational Properties

        public virtual AppUser AppUser { get; set; }
    }
}
