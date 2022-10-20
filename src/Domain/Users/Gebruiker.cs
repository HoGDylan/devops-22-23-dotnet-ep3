using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int PhoneNumber { get; set; }

        public EmailAddressAttribute EmailAddress { get; set; }
        public String Password { get; set; }
        public Boolean Active { get; set; }

    }
}
