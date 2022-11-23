using Domain.Common;
using Shared.VirtualMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.FysiekeServers
{
    public static class FysiekeServerDto
    {
        public class Index
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String ServerAddress { get; set; }
            public Hardware Hardware { get; set; }
            public Hardware HardWareAvailable { get; set; }

        }
        
        public class Detail
        {
            public int Id { get; set; }
            public List<VirtualMachineDto.Rapportage> VirtualMachines { get; set; }
        }
    }
}
