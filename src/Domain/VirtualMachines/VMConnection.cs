using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class VMConnection : ValueObject
    {

        private string _fqdn;
        private string _hostname;
        private string _username;
        private string _password;

        public String FQDN { get { return _fqdn; } set { Guard.Against.NullOrEmpty(_fqdn, nameof(_fqdn)); } }
        public String Hostname { get { return _hostname; } set { Guard.Against.NullOrEmpty(_hostname, nameof(_hostname)); } }
        public String Username { get { return _username; } set { Guard.Against.NullOrEmpty(_username, nameof(_username)); } } 
        public String Password { get { return _password; } set { Guard.Against.InvalidFormat(password, nameof(password), @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");} }

        /*
         
         * Password validation: 
             *  Min length: 8
             *  Max Length: ? 
             *  1 Uppercase letter
             *  1 Lowercase letter
             *  1 Digit
             *  1 Special character
         
         */


        public VMConnection(string FQDN, string hostname, string username, string password)
        {
            this.FQDN = FQDN;
            this.Hostname = hostname;
            this.Username = username;
            this.Password = password;
        }



        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FQDN.ToLower();
            yield return Hostname.ToLower();
            yield return Username.ToLower();
            yield return Password;
        }
    }
}
