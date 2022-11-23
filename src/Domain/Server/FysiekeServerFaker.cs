using Bogus;
using Domain.Common;
using Domain.VirtualMachines;
using Domain.VirtualMachines.VirtualMachine;
using System;
using System.Security.Cryptography;

namespace Domain.Server
{
    public class FysiekeServerFaker : Faker<FysiekeServer>
    {
        public FysiekeServerFaker()
        {
            int id = 1;

            CustomInstantiator(e => new FysiekeServer("Server " + id, GenerateRandomHardware(), e.Internet.DomainName() + "." + "hogent.be"));
            RuleFor(e => e.Id, _ => id++);
            RuleFor(e => e.VirtualMachines, _ => VirtualMachineFaker.Instance.Generate(10));
            
        }


        private Hardware GenerateRandomHardware()
        {
            int[] _memoryOptions = { 1024, 2048, 4096, 8192, 16384 };
            int[] _storageOptions = { 1000, 2000, 5000, 10000, 20000 };
            List<Hardware> res = new();

            for (int i = 0; i < 100; i++)
            {
                res.Add(new Hardware(_memoryOptions[new Random().Next(0, _memoryOptions.Count())], _storageOptions[new Random().Next(0, _storageOptions.Count())], new Random().Next(50, 200)));
            }

            return res[RandomNumberGenerator.GetInt32(0, res.Count())];
        }
    }
}
