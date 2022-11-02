using Domain.Common;
using Domain.Contract;
using Domain.Users;
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
        public String Name { get; set; }
        public String Project { get; set; }
        public VirtualMachineMode Mode { get; set; }
        public Klant Klant { get; set; }


    }
    public class Detail : Index  
    {
        public Hardware Hardware { get; set; }
        public OperatingSystemEnum OperatingSystem { get; set; }
        public VMContract Contract { get; set; }
        public VMConnection Connection { get; set; }
        public Backup BackUp { get; set; }
    }

    public class Mutate
    {
        public String Name { get; set; }   
        public String Project { get; set; }
        public VirtualMachineMode Mode { get; set; }
        public Klant Klant { get; set; }
        public Hardware Hardware { get; set; }
        public OperatingSystemEnum OperatingSystem { get; set; }
        public VMContract Contract { get; set; }
        public VMConnection Connection { get; set; }
        public Backup Backup { get; set; }

    }
}
