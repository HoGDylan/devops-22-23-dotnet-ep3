using Ardalis.GuardClauses;
using Domain.Contract;
using System.Collections.Generic;

namespace Domain.Users
{
    public class Beheerder : Gebruiker
    {
        private IList<VMContract> _contracts = new List<VMContract>();

        public AdminRole Role { get; set; }
        public Beheerder(string name, string phoneNumber, string email, string password, AdminRole role) : base(name, phoneNumber, email, password)
        {
            this.Role = Guard.Against.Null(role, nameof(role));
        }
    }
}
