using Ardalis.GuardClauses;

namespace Domain.Users
{
    public class Beheerder : Gebruiker
    {
        private AdminRole _role;
        public AdminRole Role { get { return _role;  } set { Guard.Against.Null(_role, nameof(_role)); } }
        public Beheerder(string name, string phoneNumber, string email, string password, AdminRole role) : base(name, phoneNumber, email, password)
        {
            this.Role = role;
        }
    }
}
