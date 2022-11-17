using Bogus;
using Domain.Projecten;
using Shared.Utility;


namespace Domain.Users
{
    public static class UserFaker
    {
        private static volatile int id = 1;



        public class Klant : Faker<Users.Klant>{
            public Klant()
            {
                if (id % 2 == 0)
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

                RuleFor(e => e.Id, _ => id++);
            }
        }

        public class Administrators : Faker<Administrator>
        {
            public Administrators()
            {
                CustomInstantiator(e => new Administrator(
                    e.Person.LastName,
                    e.Person.FirstName,
                    GeneratePhoneNumber(),
                    e.Person.Email,
                    PasswordGenerator.Generate(20, 2, 2, 2, 2),
                    e.PickRandom<AdminRole>()
                    ));
            }

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
