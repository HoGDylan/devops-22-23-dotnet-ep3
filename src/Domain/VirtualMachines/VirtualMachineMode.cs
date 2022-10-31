using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VirtualMachines
{
public enum VirtualMachineMode
  {
      CREATED = 0,
      READY, // When the VM is build succesfully AKA ready for deployment
      STOPPED,
      RUNNING,
      SUSPENDED, 
      TERMINATED,
      PAUSED,
      
  }
};
