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
        private readonly List<int> _memoryOptions = new() { 1, 2, 4, 8, 16, 32, 64 };
        private readonly List<int> _storageOptions = new() { 30, 50, 75, 100, 150, 200, 250, 300, 500 };
        private readonly List<DateTime?> _dateOptions = GenerateRandomDatesIncNull();
        public VirtualMachineFaker()
        {
            int id = 1;
            //CustomInstantiator(f => new VirtualMachine(f.));
            RuleFor(x => x.Id, _ => id++);
            RuleFor(x => x.Name, x => x.Commerce.ProductName());
            RuleFor(x => x.OperatingSystem, x => x.PickRandom<OperatingSystemEnum>());
            RuleFor(x => x.Hardware.Amount_vCPU, x => x.Random.Number(1, 12));
            RuleFor(x => x.Hardware.Memory, x => x.PickRandom(_memoryOptions));
            RuleFor(x => x.Hardware.Storage, x => x.PickRandom(_storageOptions));
            RuleFor(x => x.BackUp.LastBackup, x => x.PickRandom(_dateOptions));
            RuleFor(x => x.BackUp.Type, x => x.PickRandom<BackUpType>());

        }


        private static List<DateTime?> GenerateRandomDatesIncNull()
        {
            List<DateTime?> res = new();
            DateTime min = new DateTime(2022, 09, 01);

            for (int i = 0; i < 20; i++)
            {
                res.Add(min.AddDays(new Random().Next((DateTime.Now - min).Days)));
            }
            res.Add(null);

            return res;


        }
    }
}
