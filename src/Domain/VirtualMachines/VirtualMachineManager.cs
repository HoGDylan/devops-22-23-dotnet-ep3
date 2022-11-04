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

            // Check if server has enough resources for hardWare
            //if( Server.hasEnoughSpecs(hw) ) of iets dergelijks


            string VM_name = $"{os.ToString().ToLower()}.{hw.Memory}GB_RAM.";
            //return new VirtualMachine(VM_name, klant.Project, os, hw, new Backup(type, null));
            return null;
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
