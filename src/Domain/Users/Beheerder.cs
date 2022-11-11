using Ardalis.GuardClauses;

namespace Domain.Users
{
    public class Beheerder : Gebruiker
    {
        private AdminRole _role;
        public AdminRole Role { get { return _role;  } set { _role = Guard.Against.Null(value, nameof(_role)); } }
        public Beheerder(string name, string firstname, string phoneNumber, string email, string password, AdminRole role) : base(name,firstname,phoneNumber, email, password)
        {
            this.Role = role;
        }
    }
}
