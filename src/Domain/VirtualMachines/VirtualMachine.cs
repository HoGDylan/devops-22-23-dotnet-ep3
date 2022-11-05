using Ardalis.GuardClauses;
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
        public VMContract? _contract;


        public int Id;
        public String Name { get; set; }
        public String Project { get; set; }
        public OperatingSystemEnum OperatingSystem { get; set; }
        public VirtualMachineMode Mode { get; set; }
        public Hardware Hardware { get; set; }
        public VMConnection? Connection { get; set; }
        //VMConnection kan null zijn? Stel je voor dat je een VM aanmaakt. Is die dan al meteen geconnecteerd aan internet, of is er nog proces dat deze geset wordt achteraf?

        public Backup BackUp { get; set; }
        public OperatingSystemEnum OperatingSystem1 { get; }
        public VirtualMachineMode Mode1 { get; }
        public int Memory { get; }
        public int Storage { get; }
        public int Amount_vCPU { get; }
        public VMContract Contract { get; }
        public VMConnection Connection1 { get; }
        public BackUpType Type { get; }
        public DateTime LastBackup { get; }

        public VirtualMachine(string name, string project, OperatingSystemEnum os, Hardware h, Backup b)
        {
            this.Name = Guard.Against.NullOrEmpty(name, nameof(name));
            this.Project = Guard.Against.NullOrEmpty(project, nameof(project));
            this.OperatingSystem = Guard.Against.Null(os, nameof(os));
            this.Hardware = h; //validated in constructor of Hardware
            this.BackUp = b; //validated in constructor of BackUp
            this.Mode = VirtualMachineMode.STOPPED;
        }

        public VirtualMachine(string name)
        {
            Name = name;
        }

        public VirtualMachine(string name, string project, OperatingSystemEnum operatingSystem, VirtualMachineMode mode, int memory, int storage, int amount_vCPU, VMContract contract, VMConnection connection, BackUpType type, DateTime lastBackup) : this(name)
        {
            Project = project;
            OperatingSystem1 = operatingSystem;
            Mode1 = mode;
            Memory = memory;
            Storage = storage;
            Amount_vCPU = amount_vCPU;
            Contract = contract;
            Connection1 = connection;
            Type = type;
            LastBackup = lastBackup;
        }

        public void SetContract(VMContract c)
        {
            _contract = c;
        }

    }
}
