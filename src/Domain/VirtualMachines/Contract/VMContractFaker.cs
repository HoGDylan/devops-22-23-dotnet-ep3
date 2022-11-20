using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VirtualMachines.Contract
{
    public class VMContractFaker : Faker<VMContract>
    {
        private static int id = 1;


        public VMContractFaker()
        {
            CustomInstantiator(e => new VMContract(id, id, DateTime.Now.Subtract(TimeSpan.FromDays(RandomNumberGenerator.GetInt32(300))), DateTime.Now.AddDays(RandomNumberGenerator.GetInt32(200))));
            RuleFor(e => e.Id, _ => id++);
        
        }
    }
}
