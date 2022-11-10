using Ardalis.GuardClauses;

namespace Domain.Users
{
    public class ExterneKlant : Klant
    {

        private string _bedrijfsNaam;
        public String Bedrijfsnaam { get { return _bedrijfsNaam; } set {_bedrijfsNaam =  Guard.Against.NullOrEmpty(value, nameof(_bedrijfsNaam)); } }


        public ExterneKlant(string name, string phoneNumber, string email, string password, Gebruiker contactPersoon, Gebruiker contactPersoon2, string bedrijfsnaam) : base(name, phoneNumber, email, password, contactPersoon, contactPersoon2)
        {
            this.Bedrijfsnaam = bedrijfsnaam;

        }



    }
}
