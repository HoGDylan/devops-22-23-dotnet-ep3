using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VirtualMachines
{

    public enum VirtualMachineMode
    {
        STOPPED,
        RUNNING,
        SUSPENDED,
        TERMINATED,
        PAUSED
    }
};
