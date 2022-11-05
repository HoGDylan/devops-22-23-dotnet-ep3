using Ardalis.GuardClauses;
using Domain.Projecten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public abstract class Klant : Gebruiker
    {


        private Gebruiker _contactPs;
        private Gebruiker _contactPs2;
        private List<Project>? _projecten;

        public Gebruiker ContactPersoon { get { return _contactPs; } set { Guard.Against.Null(_contactPs, nameof(_contactPs)); } }
        public Gebruiker ContactPersoonReserv { get { return _contactPs2; } set { Guard.Against.Null(_contactPs2, nameof(_contactPs2)); } }

        public Klant(string name, string phoneNumber, string email, string password, Gebruiker contactPersoon, Gebruiker contactPersoon2) : base(name, phoneNumber, email, password)
        {
            this.ContactPersoon = contactPersoon;
            this.ContactPersoonReserv = contactPersoon2;
        }


        public void addProject(Project p)
        {
            if(_projecten == null)
            {
                _projecten = new List<Project>();
            }
            _projecten.Add(p);
        }


    }
}
