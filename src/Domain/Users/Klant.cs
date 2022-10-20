using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public abstract class Klant : Gebruiker
    {
        public Gebruiker ContactPersoon { get; set; }
        public Gebruiker ContactPersoonReserve { get; set; }
        public String Project { get; set; }

        protected Klant(string name, string phoneNumber, string email, string password, Gebruiker contactPersoon, Gebruiker contactPersoon2, string project) : base(name, phoneNumber, email, password){
            this.ContactPersoon = Guard.Against.Null(contactPersoon, nameof(contactPersoon));
            this.ContactPersoonReserve = Guard.Against.Null(contactPersoon2, nameof(contactPersoon2));
            this.Project = Guard.Against.NullOrEmpty(project, nameof(project));
        }




 
    }
}
