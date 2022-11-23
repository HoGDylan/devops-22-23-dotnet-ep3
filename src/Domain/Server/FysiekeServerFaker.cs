﻿using Bogus;
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

            Hardware hw = null;


            CustomInstantiator(e => {
                hw = GenerateRandomHardware();
                return new FysiekeServer("Server " + id, hw, e.Internet.DomainName() + "." + "hogent.be");
                });
       
            RuleFor(e => e.Id, _ => id++);
            RuleFor(e => e.VirtualMachines, _ => VirtualMachineFaker.Instance.Generate(10));
            RuleFor(e => e.HardWareAvailable, _ => new Hardware( hw.Memory - new Random().Next(1, hw.Memory), hw.Storage -  new Random().Next(1, hw.Storage), hw.Amount_vCPU - new Random().Next(1, hw.Amount_vCPU)));
            
        }


        private Hardware GenerateRandomHardware()
        {
            int[] _memoryOptions = { 64000, 128000, 256000, 512000, 1024000 };
            int[] _storageOptions = { 10000, 20000, 50000, 100000, 200000 };
            int[] _cpus = { 24, 32, 40, 48, 56, 64 };
            List<Hardware> res = new();

            return new Hardware(_memoryOptions[new Random().Next(0, _memoryOptions.Count())], _storageOptions[new Random().Next(0, _storageOptions.Count())], _cpus[new Random().Next(0, _cpus.Count())]);
        }
    }
}
