using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VirtualMachines.BackUp
{
    public enum BackUpType
    {
        CUSTOM = 1,
        DAILY,
        WEEKLY,
        MONTHLY,
    }
}
