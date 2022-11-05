using Ardalis.GuardClauses;
using Domain.Common;
using Domain.VirtualMachines;
using Shared.Utility;
using System.Security.Cryptography;
 
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
        public String Naam { get { return _name; } set { Guard.Against.NullOrEmpty(_name, nameof(_name)); } }
        public String ServerAddress { get { return _serverAddress; } set { Guard.Against.NullOrEmpty(_serverAddress, nameof(_serverAddress)); } }
        public Hardware HardWare { get { return _hardWare; } set { Guard.Against.Null(_hardWare, nameof(_hardWare)); } }
        public int MemoryAvailable { get { return _memoryAvailable; } set { Guard.Against.Negative(_memoryAvailable, nameof(_memoryAvailable)); } }
        public int StorageAvailable { get { return _storageAvailable; } set { Guard.Against.Negative(_storageAvailable, nameof(_storageAvailable)); } }
        public int VCPUsAvailable { get { return _vCPUsAvailable; } set { Guard.Against.Negative(_vCPUsAvailable, nameof(_vCPUsAvailable)); } }



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
            string pass = PasswordGenerator.CreatePassword(RandomNumberGenerator.GetInt32(10)+20, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(3) + 1);

            vm.Connection = new VMConnection(ServerAddress, vm.Project.Klant.Name, "admin", pass);
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
                vm.FysiekeServer = null;
                vm.Mode = VirtualMachineMode.TERMINATED;
            }
        }

        public VirtualMachine GetVirtualMachineById(int id)
        {
            return _vms.First(x => x.Id == id);
        }


    }
}
