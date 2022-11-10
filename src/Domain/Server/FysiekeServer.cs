using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Users;
using Domain.VirtualMachines;
using Shared.Utility;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Server
{
    public class FysiekeServer : Entity
    {

        private List<VirtualMachine> _vms = new();
        private string _name;
        private string _serverAddress;
        private Hardware _hardWare;
        private int _memoryAvailable;
        private int _storageAvailable;
        private int _vCPUsAvailable;

        public int Id { get; set; }
        public String Naam { get { return _name; } set { _name = Guard.Against.NullOrEmpty(value, nameof(_name)); } }
        public String ServerAddress { get { return _serverAddress; } set { _serverAddress =  Guard.Against.NullOrEmpty(value, nameof(_serverAddress)); } }
        public Hardware HardWare { get { return _hardWare; } set {_hardWare =  Guard.Against.Null(value, nameof(_hardWare)); } }
        public int MemoryAvailable { get { return _memoryAvailable; } set {_memoryAvailable =  Guard.Against.Negative(value, nameof(_memoryAvailable)); } }
        public int StorageAvailable { get { return _storageAvailable; } set { _storageAvailable = Guard.Against.Negative(value, nameof(_storageAvailable)); } }
        public int VCPUsAvailable { get { return _vCPUsAvailable; } set { _vCPUsAvailable = Guard.Against.Negative(value, nameof(_vCPUsAvailable)); } }



        public FysiekeServer(string naam, Hardware hw,  string s_adres, int mem_available, int stor_available, int vCPU_avaiable)
        {

            this.Naam = naam;
            this.HardWare = hw;
            this.ServerAddress = s_adres;
            this.MemoryAvailable = mem_available;
            this.StorageAvailable = stor_available;
            this.VCPUsAvailable = vCPU_avaiable ;
        }


        public void AddConnection(VirtualMachine vm)
        {
            string pass = PasswordGenerator.Generate(RandomNumberGenerator.GetInt32(10)+20, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(3) + 1);


   


            vm.Connection = new VMConnection(ServerAddress, GetRandomIpAddress(), "admin", pass);
            vm.Mode = VirtualMachineMode.READY;
        }


        public void AddToServer(VirtualMachine vm)
        {
            MemoryAvailable -= vm.Hardware.Memory;
            VCPUsAvailable -= vm.Hardware.Amount_vCPU;
            StorageAvailable -= vm.Hardware.Storage;
            AddConnection(vm);
            _vms.Add(vm);
        }

        public void RemoveFromServer(VirtualMachine vm)
        {
            if (_vms.Contains(vm))
            {
                MemoryAvailable += vm.Hardware.Memory;
                VCPUsAvailable += vm.Hardware.Amount_vCPU;
                StorageAvailable += vm.Hardware.Storage;
                _vms.Remove(vm);
            }
        }

        //kan eventueel weg als we met service gaan werken
        public VirtualMachine GetVirtualMachineById(int id)
        {
            return _vms.First(x => x.Id == id);
        }


        //IP om te connecteren met de VM
        public IPAddress GetRandomIpAddress()
        {
            var random = new Random();
            string ip = $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";


            return IPAddress.Parse(ip);

        }

    }
}
