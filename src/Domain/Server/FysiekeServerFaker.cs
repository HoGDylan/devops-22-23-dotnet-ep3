using Bogus;
using Domain.Common;
using Domain.VirtualMachines;
using Domain.VirtualMachines.VirtualMachine;
using System;

namespace Domain.Server
{
    public class FysiekeServerFaker : Faker<FysiekeServer>
    {
        private static readonly int[] _memoryOptions = { 1024, 2048, 4096, 8192, 16384 };
        private static readonly int[] _storageOptions = { 1000, 2000, 5000, 10000, 20000 };

        private List<Hardware> _hardWareOptions = GenerateRandomHardware();
        public FysiekeServerFaker()
        {
            int id = 1;

            CustomInstantiator(e => new FysiekeServer("Server " + id, e.PickRandom(_hardWareOptions), e.Internet.DomainName() + "." + "hogent.be"));
            RuleFor(e => e.Id, _ => id++);
            RuleFor(e => e.VirtualMachines, _ => VirtualMachineFaker.Instance.Generate(10));
            
        }


        private static List<Hardware> GenerateRandomHardware()
        {
            List<Hardware> res = new();

            for (int i = 0; i < 100; i++)
            {
                res.Append(new Hardware(_memoryOptions[new Random().Next(0, _memoryOptions.Count())], _storageOptions[new Random().Next(0, _storageOptions.Count())], new Random().Next(50, 200)));
            }
            return res;
        }
    }
}
