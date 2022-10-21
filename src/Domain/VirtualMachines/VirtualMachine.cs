using Ardalis.GuardClauses;
using Bogus.DataSets;
using Domain.Common;
using Domain.Contract;
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
        private VMContract? _contract = null;
        private string _name;
        private string _project;
        private OperatingSystemEnum _operatingSystem;
        private VirtualMachineMode _mode;


        public int Id;
        public String Name { get { return _name; } set {Guard.Against.NullOrEmpty(_name, nameof(_name)); } }
        public String Project { get { return _project; } set {Guard.Against.NullOrEmpty(_project, nameof(_project)); } }
        public OperatingSystemEnum OperatingSystem { get { return _operatingSystem; } set {Guard.Against.Null(_operatingSystem, nameof(_operatingSystem)); } }
        public VirtualMachineMode Mode { get { return _mode; } set { Guard.Against.Null(_mode, nameof(_mode)); } }
        public Hardware Hardware { get; set; }
        public VMConnection? Connection { get; set; }
        public Backup BackUp { get; set; }



        public VirtualMachine(string name, string project, OperatingSystemEnum os, Hardware h, Backup b)
        {
            this.Name = name;
            this.Project = project;
            this.OperatingSystem = os;
            this.Hardware = h;
            this.BackUp = b;
            this.Mode = VirtualMachineMode.STOPPED;
        }

        public void SetContract(VMContract c)
        {
            _contract = c;
        }

    }
}
