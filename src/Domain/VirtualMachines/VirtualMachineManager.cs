using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Contract;
using Domain.Projecten;
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

        public VirtualMachine CreateVM(string name, Project p, OperatingSystemEnum os, Hardware hw, Backup b, Klant k, DateTime start, DateTime end)
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

            return new VirtualMachine(name, p, os, hw, b, k, start, end);
        }



        public bool DeleteVM(int id)
        {
            VirtualMachine? vm = _vms.FirstOrDefault(x => x.Id == id, null);
            

            if (vm == null) return false;
            

            _vms.Remove(vm);

            if (vm.Server == null) return true;



            FysiekeServer? server = _fysiekeServers.FirstOrDefault(x => x.Id == vm.Server.Id, null);

            if(server == null)
            {
                throw new ArgumentException("VM was connected with a server that is not known by the VM Manager.");
            }

            _fysiekeServers.Remove(server);

            server.HardWare = new Hardware(vm.Hardware.Memory + vm.Server.HardWare.Memory, vm.Hardware.Storage + vm.Server.HardWare.Storage, vm.Hardware.Amount_vCPU + vm.Server.HardWare.Amount_vCPU);

            _fysiekeServers.Add(server);

            return true;

        }




        /*
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
        */
    }
}
