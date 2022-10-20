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
        public int Id;
        public string Name { get; set; }
        public VirtualMachineMode mode;


    }
}
