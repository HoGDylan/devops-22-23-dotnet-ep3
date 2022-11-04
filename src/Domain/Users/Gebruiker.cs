using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Validators;
using System;

namespace Domain
{
    public abstract class Gebruiker : Entity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String HogentEmail { get; set; }

        /*
         * Password validation: 
             *  Min length: 6
             *  Max Length: ? 
             *  1 Uppercase letter
             *  1 Lowercase letter
             *  1 Digit
         */

        public Gebruiker(string name, string phoneNumber, string email, string password)
        {
            this.Name = Guard.Against.NullOrEmpty(name, nameof(name));
            if (Validator.IsPhoneNumberValid(phoneNumber)) PhoneNumber = phoneNumber;
            if (Validator.IsValidEmail(email)) Email = email;
            this.Password = Guard.Against.InvalidFormat(password, nameof(password), @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$");
        }

    }
}
