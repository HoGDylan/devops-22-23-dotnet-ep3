using Ardalis.GuardClauses;
using Bogus.DataSets;
using Domain.Common;
using Domain.Contract;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VirtualMachines
{
    public class VirtualMachine : Entity
    {
        private VMContract _vmContract;

        private string _name;
        private string _project;
        private OperatingSystemEnum _operatingSystem;
        private VirtualMachineMode _mode;
        private Klant _customer;


        public int Id;
        public String Name { get { return _name; } set {Guard.Against.NullOrEmpty(_name, nameof(_name)); } }
        public String Project { get { return _project; } set {Guard.Against.NullOrEmpty(_project, nameof(_project)); } }
        public OperatingSystemEnum OperatingSystem { get { return _operatingSystem; } set {Guard.Against.Null(_operatingSystem, nameof(_operatingSystem)); } }
        public VirtualMachineMode Mode { get { return _mode; } set { Guard.Against.Null(_mode, nameof(_mode)); } }
        public Hardware Hardware { get; set; }
        public VMConnection? Connection { get; set; }
        public Backup BackUp { get; set; }
        public Klant Customer { get { return _customer; } set { Guard.Against.Null(_customer, nameof(_customer)); } }
        public VMContract Contract { get { return _vmContract; } set { Guard.Against.Null(_vmContract, nameof(_vmContract)); } }

        //virtual machine used for templates.
        //builder will add: VMconnection
        public VirtualMachine(string name, string project, OperatingSystemEnum os, Hardware h, Backup b, Klant k, VMContract vm_c)
        {
            this.Name = name;
            this.Project = project;
            this.OperatingSystem = os;
            this.Hardware = h;
            this.BackUp = b;
            this.Customer = k;
            this.Mode = VirtualMachineMode.CREATED;
            this.Contract = vm_c;

        }

        //virtual machine for custom (made with builder)
        //builder will add hardware, operating system, backup, VMConnection
        public VirtualMachine(string name, string project, Klant g, VMContract vm_c)
        {
            this.Name = name;
            this.Project = project;
            this.Mode = VirtualMachineMode.CREATED;
            this.Customer = g;
            this.Contract = vm_c;
        }

   
    }
}
