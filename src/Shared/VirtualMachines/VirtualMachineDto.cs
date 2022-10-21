using Domain.Common;
using Domain.VirtualMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VirtualMachines;

public static class VirtualMachineDto
{
    public class Index
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VirtualMachineMode mode;
    }
    public class Detail : Index
    {
        //public Hardware 
    }
}
