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

        public String FQDN { get; set; }
        public String Hostname { get; set; }
        public String Username { get; set; } 
        public String Password { get; set; }  
        
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
            this.FQDN = Guard.Against.NullOrEmpty(FQDN, nameof(FQDN));
            this.Hostname = Guard.Against.NullOrEmpty(hostname, nameof(hostname));
            this.Username = Guard.Against.NullOrEmpty(username, nameof(username));
            this.Password = Guard.Against.InvalidFormat(password, nameof(password), @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
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
