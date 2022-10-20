using Ardalis.GuardClauses;

namespace Domain.Users
{
    public class Beheerder : Gebruiker
    {
        public AdminRole Role { get; set; }
        public Beheerder(string name, string phoneNumber, string email, string password, AdminRole role) : base(name, phoneNumber, email, password)
        {
            this.Role = Guard.Against.Null(role, nameof(role));
        }
    }
}
