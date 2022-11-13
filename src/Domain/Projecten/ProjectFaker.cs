using Bogus;
using Domain.Users;
using Domain.VirtualMachines;
using Domain.VirtualMachines.VirtualMachine;

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
            RuleFor(x => x.Klant, _ => new UserFaker.Klant().Generate());

        }
    }
}
