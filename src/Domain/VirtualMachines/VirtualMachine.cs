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

        public void SetContract(VMContract c)
        {
            _contract = c;
        }

    }
}
