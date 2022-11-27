using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Users
{
    public class ExterneKlant : Klant
    {

        private string _bedrijfsNaam;
        private ContactDetails _contactpersoon;
        private ContactDetails _resContactpersoon;
        public String Bedrijfsnaam { get { return _bedrijfsNaam; } set {_bedrijfsNaam =  Guard.Against.NullOrEmpty(value, nameof(_bedrijfsNaam)); } }
        public ContactDetails Contactpersoon { get { return _contactpersoon; } set { _contactpersoon = value; } }
        public ContactDetails ResContactpersoon { get { return _contactpersoon; } set { _contactpersoon = value; } }


        public ExterneKlant(string name, string firstname, string phoneNumber, string email, string password, string bedrijfsnaam, ContactDetails contactpersoon, ContactDetails resContactpersoon) : base(name, firstname, phoneNumber, email, password)
        {
            this.Bedrijfsnaam = bedrijfsnaam;
            this.Contactpersoon = contactpersoon;
            this.ResContactpersoon = resContactpersoon;
        }



    }
}
