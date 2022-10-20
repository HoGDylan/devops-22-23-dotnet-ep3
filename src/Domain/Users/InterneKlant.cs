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
        public Course Opleiding { get; set; }

        public InterneKlant(string name, string phoneNumber, string email, string password, Gebruiker contactPersoon, Gebruiker contactPersoon2, string project, Course opleiding) : base(name, phoneNumber, email, password, contactPersoon, contactPersoon2, project)
        {
            this.Opleiding = Guard.Against.Null(opleiding, nameof(opleiding));

        }


    }
}
