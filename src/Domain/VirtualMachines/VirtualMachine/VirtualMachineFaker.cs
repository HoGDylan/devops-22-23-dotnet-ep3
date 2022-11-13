using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Domain.Common;
using Domain.Projecten;
using Domain.VirtualMachines.BackUp;

namespace Domain.VirtualMachines.VirtualMachine
{

    public class VirtualMachineFaker : Faker<VirtualMachine>
    {

        private static readonly int[] _memoryOptions = { 1, 2, 4, 8, 16, 32, 64 };
        private static readonly int[] _storageOptions = { 30, 50, 75, 100, 150, 200, 250, 300, 500 };

        //private readonly IEnumerable<DateTime?> _dateOptions = GenerateRandomDatesIncNull();
        private readonly List<Hardware> _hardWareOptions = GenerateRandomHardware();
        private readonly List<Backup> _backupOptions = GenerateRandomBackups();

        public VirtualMachineFaker()
        {
            int id = 1;



            CustomInstantiator(e => new VirtualMachine(
                e.Commerce.ProductName(),
                e.PickRandom<OperatingSystemEnum>(),
                e.PickRandom(_hardWareOptions),
                e.PickRandom(_backupOptions)
                ));

            RuleFor(x => x.Id, _ => id++);
            RuleFor(x => x.Connection, _ => new Random().Next(0, 2) % 1 == 0 ? new VMConnection("MOCK-FQDN", GetRandomIpAddress(), "MOCK-USER", "MOCK-PASWORD@aa123") : null);
            RuleFor(x => x.Mode, x => x.PickRandom<VirtualMachineMode>());

        }


        private static List<DateTime?> GenerateRandomDatesIncNull()
        {
            List<DateTime?> res = new();
            DateTime min = new DateTime(2022, 09, 01);

            for (int i = 0; i < 100; i++)
            {
                res.Add(min.AddDays(new Random().Next((DateTime.Now - min).Days)));
            }
            res.Add(null);

            return res;


        }

        private static List<Hardware> GenerateRandomHardware()
        {
            List<Hardware> res = new();

            for (int i = 0; i < 100; i++)
            {
                res.Add(new Hardware(_memoryOptions[new Random().Next(0, _memoryOptions.Count())], _storageOptions[new Random().Next(0, _storageOptions.Count())], new Random().Next(1, 13)));
            }
            return res;
        }

        private static List<Backup> GenerateRandomBackups()
        {
            List<Backup> res = new();

            for (int i = 0; i < 100; i++)
            {
                int r = new Random().Next(0, 10);
                Backup a;



                if (r == 1)
                    a = new Backup(BackUpType.DAILY, DateTime.Now.Subtract(TimeSpan.FromMinutes((i + 1) * 20)));
                else if (r == 2)
                    a = new Backup(BackUpType.CUSTOM, DateTime.Now.Subtract(TimeSpan.FromHours((i + 1) * 50)));
                else if (r <= 6)
                    a = new Backup(BackUpType.WEEKLY, DateTime.Now.Subtract(TimeSpan.FromDays(new Random().NextDouble() * 7)));
                else
                    a = new Backup(BackUpType.MONTHLY, DateTime.Now.Subtract(TimeSpan.FromDays(new Random().Next(30))));


                res.Add(a);


            }
            return res;

        }

        private static IPAddress GetRandomIpAddress()
        {
            var random = new Random();
            var data = new byte[4];
            random.NextBytes(data);

            return new IPAddress(data);
        }
    }
}
