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

        public VMContractFaker()
        {

            CustomInstantiator(e => new VMContract(e.Random.Int(1, 30), e.Random.Int(1, 30), new DateTime(1650000000000 + new Random().NextInt64(15000000000)), new DateTime().AddDays(new Random().NextDouble() * 1000))); 
        }
    }
}
