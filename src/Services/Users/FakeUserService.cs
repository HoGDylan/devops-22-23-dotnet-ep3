using Domain.Users;
using Shared.Users;


namespace Services.Users
{
    public class FakeUserService: IUserService
    {
        private List<Klant> _klanten;
        private List<Administrator> _admins;


        public FakeUserService()
        {
            _klanten = new UserFaker.Klant().Generate(20);
            _admins = new UserFaker.Administrators().Generate(3);

        }
    }
}
