using Ardalis.GuardClauses;
using Bogus.DataSets;
using Domain.Common;
using Domain.Validators;

namespace Domain
{
    public abstract class Gebruiker : Entity
    {

        private string _name;
        private string _phoneNr;
        private string _email;
        private string _password;

        public int Id { get; set; }
        public String Name { get { return _name; } set { Guard.Against.NullOrEmpty(_name, nameof(_name)); } }
        public String PhoneNumber{ get { return _phoneNr; } set{if (Validator.IsPhoneNumberValid(_phoneNr)) PhoneNumber = _phoneNr;}}
        public String Email { get { return _email; } set { if (Validator.IsValidEmail(_email)) Email = _email; } }
        public String Password { get { return _password;} set { Guard.Against.InvalidFormat(_password, nameof(_password), @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$"); } }

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
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Password = password;
        }

    }
}
