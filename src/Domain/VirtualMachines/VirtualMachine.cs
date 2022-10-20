using Ardalis.GuardClauses;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VirtualMachines
{
    internal class VirtualMachine: Entity
    {
        public string name;
        public string OperatingSytem { get; set; }
        public VirtualMachineMode mode;
        public Hardware hardware;
        public Backup backup;
        public VMConnection connection;
        public string Name
        {
            get { return name; }
            set { name = Guard.Against.NullOrWhiteSpace(value, nameof(name));}
        }
        public Hardware Hardware
        {
            get => hardware;
            set => hardware = Guard.Against.Null(value, nameof(hardware));
        }
        private VirtualMachine()
        {

        }
        public VirtualMachine(string name, string operatingSytem, VirtualMachineMode mode, Hardware hardware, Backup backup, VMConnection connection)
        {
            Name = name;
            OperatingSytem = operatingSytem;
            this.mode = mode;
            this.hardware = hardware;
            this.backup = backup;
            this.connection = connection;
        }
    }
}
