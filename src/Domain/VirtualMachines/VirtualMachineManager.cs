using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Users;
using System.Collections;

namespace Domain.VirtualMachines
{
    public class VirtualMachineManager
    {
        public IEnumerable<VirtualMachine> VirtualMachines { get; set; }

        //for testing
        public VirtualMachineManager(List<VirtualMachine> current_machines)
        {
            this.VirtualMachines = Guard.Against.NullOrEmpty(current_machines);
        }

        public VirtualMachine GetVirtualMachineById(int id)
        {
            return VirtualMachines.First(x => x.Id == id);
        }

        public List<VirtualMachine> GetAllVirtualMachines()
        {
            return VirtualMachines.ToList();
        }

        public VirtualMachine CreateVM(Klant klant, OperatingSystemEnum os, Hardware hw, BackUpType type)
        {

            // Check if server has enough resources for hardWare
            //if( Server.hasEnoughSpecs(hw) ) of iets dergelijks


            string VM_name = $"{os.ToString().ToLower()}.{hw.Memory}GB_RAM.";
            return new VirtualMachine(VM_name, klant.Project, os, hw, new Backup(type, null));
        }


        public bool DeleteVM(int id)
        {
            int check = VirtualMachines.Count();
            VirtualMachines = VirtualMachines.Where(x => x.Id != id).ToList();
            return VirtualMachines.Count() < check;
        }

        public void EditVM(int id, Hardware hw, BackUpType type, Klant k, VMConnection connection)
        {
            VirtualMachine vm = VirtualMachines.First(x => x.Id == id);

            if (vm != null)
            {
                //Deletes vm out of the list of VMS
                VirtualMachines = VirtualMachines.Where(x => x.Id != id).ToList();

                vm.Hardware = hw;
                vm.BackUp.Type = type;
                vm.Project = k.Project;
                vm.Connection = connection;

                //Adds it again after changing it
                VirtualMachines.Append(vm);

            }

            
        }
    }
}
