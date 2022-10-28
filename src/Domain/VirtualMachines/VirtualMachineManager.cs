using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Contract;
using Domain.Server;
using Domain.Users;
using System.Collections;

namespace Domain.VirtualMachines
{
    public class VirtualMachineManager
    {
        private IList<VirtualMachine> _vms = new List<VirtualMachine>();
        private IList<FysiekeServer> _fysiekeServers = new List<FysiekeServer>();

        //for testing
        public VirtualMachineManager(IList<VirtualMachine> current_machines)
        {
            _vms = Guard.Against.Null(current_machines);
            _fysiekeServers = Guard.Against.Null(_fysiekeServers);

        }


        public VirtualMachine GetVirtualMachineById(int id)
        {
            return _vms.First(x => x.Id == id);
        }

        public List<VirtualMachine> GetAll_vms()
        {
            return _vms.ToList();
        }

        public VirtualMachine CreateVM(Klant klant, OperatingSystemEnum os, Hardware hw, BackUpType type)
        {

            FysiekeServer server = _fysiekeServers.First(e => e.IsEnabled && e.VCPUsAvailable > hw.Amount_vCPU && e.StorageAvailable > hw.Storage && e.MemoryAvailable > hw.Memory);

            if(server == null)
            {
                throw new ArgumentException("None of the servers have the available resources available or the server that has resources available is not enabled.");
            }

            _fysiekeServers.Remove(server);

            server.MemoryAvailable -= hw.Memory;
            server.VCPUsAvailable -= hw.Amount_vCPU;
            server.StorageAvailable -= hw.Storage;

            _fysiekeServers.Add(server);

            return new VirtualMachine(os, hw, new Backup(type, null), klant);
        }
        public VirtualMachine CreateVM(Klant klant)
        {
            return new VirtualMachine(klant);
        }

        public bool DeleteVM(int id)
        {
            int check = _vms.Count();
            _vms = _vms.Where(x => x.Id != id).ToList();
            return _vms.Count() < check;
        }

        public void EditVM(int id, Hardware hw, BackUpType type, Klant k, VMConnection connection)
        {
            VirtualMachine vm = _vms.First(x => x.Id == id);

            if (vm != null)
            {
                //Deletes vm out of the list of VMS
                DeleteVM(id);
                vm.Hardware = hw;
                vm.BackUp.Type = type;
                vm.Project = k.Project;
                vm.Connection = connection;

                //Adds it again after changing it
                _vms.Append(vm);

            }

            
        }
    }
}
