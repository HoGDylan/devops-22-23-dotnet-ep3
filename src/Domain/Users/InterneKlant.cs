using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class InterneKlant : Klant
    {

        private Course _opleiding;

        public Course Opleiding { get { return _opleiding; }; set { Guard.Against.Null(_opleiding, nameof(_opleiding)); }
        }

        public InterneKlant(string name, string phoneNumber, string email, string password, Gebruiker contactPersoon, Gebruiker contactPersoon2, string project, Course opleiding) : base(name, phoneNumber, email, password, contactPersoon, contactPersoon2, project)
        {
            this.Opleiding = opleiding;
        }


    }
}
