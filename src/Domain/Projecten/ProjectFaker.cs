using Bogus;
using Domain.VirtualMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projecten
{
    public class ProjectFaker : Faker<Project>
    {
        public ProjectFaker()
        {
            int id = 1;

            CustomInstantiator(e => new Project(e.Commerce.ProductName()));
            RuleFor(x => x.Id, _ => id++);
            RuleFor(x => x.VirtualMachines, _ => new VirtualMachineFaker().GenerateBetween(1, 5));
            RuleFor(x => x.Klant, _ => new KlantFaker().Generate(1));
        }
    }
}
