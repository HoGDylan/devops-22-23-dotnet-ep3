using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Contract;
using Domain.Projecten;
using Domain.Server;
using System.Net;

namespace Domain.VirtualMachines
{
    public class VirtualMachine : Entity
    {

        private VMContract _vmContract;


        private string _name;
        private OperatingSystemEnum _operatingSystem;
        private VirtualMachineMode _mode;
    //    private Project _project;
      //  private FysiekeServer? _server;

        public String Name { get { return _name; } set { Guard.Against.NullOrEmpty(_name, nameof(_name)); } }

        public OperatingSystemEnum OperatingSystem { get { return _operatingSystem; } set { Guard.Against.Null(_operatingSystem, nameof(_operatingSystem)); } }
        public VirtualMachineMode Mode { get { return _mode; } set { Guard.Against.Null(_mode, nameof(_mode)); } }
        public Hardware Hardware { get; set; }
        public Backup BackUp { get; set; }
        public VMConnection? Connection { get; set; }
        public VMContract? Contract { get { return _vmContract; } set { Guard.Against.Null(_vmContract, nameof(_vmContract)); } }
       // public Project? Project { get { return _project; } set { Guard.Against.Null(_project, nameof(_project)); } }
      //  public FysiekeServer? FysiekeServer { get { return _server; } set { Guard.Against.Null(_server, nameof(_server)); } }

        public VirtualMachine(string n, OperatingSystemEnum os, Hardware h, Backup b)
        {
            this.Name = n;
            this.OperatingSystem = os;
            this.Hardware = h;
            this.BackUp = b;
            this.Mode = VirtualMachineMode.WAITING_APPROVEMENT;
        }

        public void AddConnection(string FQDN, IPAddress hostname, string username, string password)
        {
            this.Connection = new VMConnection(FQDN, hostname, username, password);
            this.Mode = VirtualMachineMode.READY;
        }
 


    }
}
