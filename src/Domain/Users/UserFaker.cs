using Bogus;
using Domain.Projecten;
using Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Domain.Users
{


    public class UserFaker : Faker<Users.User>
    {
        private static int id = 1;

        private List<User> _users = new();

        private static UserFaker _instance;
        public static UserFaker Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new UserFaker();
                }
                return _instance;
            }
        }



        public UserFaker()
        {

            CustomInstantiator(e => new User(
                e.Person.LastName,
                e.Person.FirstName,
                GeneratePhoneNumber(),
                e.Person.Email,
                PasswordGenerator.Generate(20, 2, 2, 2, 2),
                e.PickRandom<Role>(),
                null,
                e.PickRandom<Type>(),
                null,
                null,
                e.PickRandom<Course>().ToString()
            ));




            RuleFor(e => e.Id, _ => id++);
        }

        public override List<Users.User> Generate(int count, string ruleSets = null)
        {
            List<Users.User> output;

            if (_users.Count() < count)
            {
                output = base.Generate(count, ruleSets);
                output.ForEach(e => _users.Add(e));
            }
            else
            {
                if (count == 1)
                {
                    output = new List<Users.User>() { _users[RandomNumberGenerator.GetInt32(0, _users.Count())] };
                }
                else
                {
                    output = _users.GetRange(0, count);
                }

            }

            return output;
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
