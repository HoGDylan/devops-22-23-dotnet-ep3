using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VirtualMachines.VirtualMachine
{
    public enum VirtualMachineMode
    {
        WAITING_APPROVEMENT,       // No connection || No server
        READY,                     // has connection && server
        RUNNING,
        PAUSED,
        STOPPED,

    }
};
