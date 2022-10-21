using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Domain.VirtualMachines
{

    public class VirtualMachineFaker : Faker<VirtualMachine>
    {
        public VirtualMachineFaker()
        {
          //  CustomInstantiator(f => new VirtualMachine(f.));
          //  RuleFor(x => x.Id, f => f.Random.Int(1));
            
        }
    }
}
