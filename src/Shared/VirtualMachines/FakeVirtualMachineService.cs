using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Shared.VirtualMachines
{
    internal class FakeVirtualMachineService
    {

        private readonly List<VirtualMachineDto.Detail> _virtualMachines = new();

        public FakeVirtualMachineService()
        {
            var virtualMachineIds = 0;
            var virtualMachineFaker = new Faker<VirtualMachineDto.Detail>()
                .UseSeed(1337);
                //.RuleFor(x => x.Id, _ => ++virtualMachineIds)
                //.RuleFor(x => x.Name, f => f.Internet.Url)
                //.RuleFor(x => x.Description, f => f.Internet.Description);
            //_virtualMachines = virtualMachineFaker.Generate(30);
        }

        /*public Task<IEnumerable<VirtualMachineDto.Index>> GetIndexAsync()
        {
            /*return TaskFromResult(_virtualMachines.Select(x => new ProductDto.Index
            {
                Id = x.Id,
                Name = x.Name,

            }));
        }*/
    }
}
