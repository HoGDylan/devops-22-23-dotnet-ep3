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


        private Gebruiker? _contactPs;
        private Gebruiker? _contactPs2;
        private List<Project> _projecten = new();



        public Gebruiker ContactPersoon { get { return _contactPs; } set { _contactPs=  Guard.Against.Null(value, nameof(_contactPs)); } }
        public Gebruiker ContactPersoonReserv { get { return _contactPs2; } set {_contactPs2 =  Guard.Against.Null(value, nameof(_contactPs2)); } }
        public List<Project> Projecten { get { return _projecten; } }


        public Klant(string name, string firstname, string phoneNumber, string email, string password) : base(name,firstname, phoneNumber, email, password)
        {
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
