using Ardalis.GuardClauses;
using Domain.VirtualMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projecten
{

    public class Project
    {

        private List<VirtualMachine> _vms = new();
        private string _name;



        public int Id { get; set; }
        public String Name { get { return _name; } set {Guard.Against.NullOrEmpty(_name, nameof(_name)); } }

        public Project(string name) {
            this.Name = name;
        }


        public List<VirtualMachine> GetVirtualMachines()
        {
            return _vms;
        }
        public VirtualMachine GetVirtualMachineById(int id)
        {
            return _vms.First(e => e.Id == id);
        }
        
        // name = substring dus meerdere mogelijkheden 
        public List<VirtualMachine> GetVirtualMachineByName(string name)
        {
            return _vms.FindAll(e => e.Name.ToLower().Contains(name));

        }
        public void AddVirtualMachine(VirtualMachine vm)
        {
            _vms.Add(vm);
        }
        public void RemoveVirtualMachine(VirtualMachine vm)
        {
            _vms.Remove(vm);
        }
    }
}
