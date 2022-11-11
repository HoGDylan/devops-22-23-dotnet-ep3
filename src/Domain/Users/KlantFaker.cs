using Bogus;
using Domain.Projecten;
using Shared.Utility;


namespace Domain.Users
{
    public class KlantFaker : Faker<Klant>
    {
        public KlantFaker()
        {
            int id = 1;

            if(id % 2 == 0)
            {
               CustomInstantiator(e => new InterneKlant(
                   e.Person.LastName,
                   e.Person.FirstName,
                   GeneratePhoneNumber(),
                   e.Person.Email,
                   PasswordGenerator.Generate(20, 2, 2, 2, 2),
                   e.PickRandom<Course>()
               ));

             }
            else
            {
                CustomInstantiator(e => new ExterneKlant(
                     e.Person.LastName,
                     e.Person.FirstName,
                     GeneratePhoneNumber(),
                     e.Person.Email,
                     PasswordGenerator.Generate(20, 2, 2, 2, 2),
                     e.Company.CompanyName()
               ));

            }
            RuleFor(e => e.Projecten, new ProjectFaker().GenerateBetween(1, 5));
            RuleFor(e => e.Id, _ => id++);


        }


        private static string GeneratePhoneNumber()
        {
            string output = "04";


            for (int i = 0; i < 8; i++)
            {
                output += (new Random().Next(0, 10)).ToString();
            }

            return output;
        }
    }
}
