using Ardalis.GuardClauses;
using System;

namespace Domain.Users
{
    public class ExterneKlant : Klant
    {
        public String Bedrijfsnaam { get; set; }


        public ExterneKlant(string name, string phoneNumber, string email, string password, Gebruiker contactPersoon, Gebruiker contactPersoon2, string project, string bedrijfsnaam) : base(name, phoneNumber, email, password, contactPersoon, contactPersoon2, project)
        {
            this.Bedrijfsnaam = Guard.Against.NullOrEmpty(bedrijfsnaam, nameof(bedrijfsnaam));

        }



    }
}
