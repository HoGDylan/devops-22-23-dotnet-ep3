using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Projecten;
using Domain.Server;
using Domain.VirtualMachines.BackUp;
using Domain.VirtualMachines.Contract;
using System.Net;

namespace Domain.VirtualMachines.VirtualMachine
{
    public class VirtualMachine : Entity
    {

        private VMContract _vmContract;


        private string _name;
        private OperatingSystemEnum _operatingSystem;
        private VirtualMachineMode _mode;
        private Project _project;
        private FysiekeServer? _server;

        public string Name { get { return _name; } set { _name = Guard.Against.NullOrEmpty(value, nameof(_name)); } }

        public OperatingSystemEnum OperatingSystem { get { return _operatingSystem; } set { _operatingSystem = Guard.Against.Null(value, nameof(_operatingSystem)); } }
        public VirtualMachineMode Mode { get { return _mode; } set { _mode = Guard.Against.Null(value, nameof(_mode)); } }
        public Hardware Hardware { get; set; }
        public Backup BackUp { get; set; }
        public VMConnection? Connection { get; set; }
        public VMContract Contract { get { return _vmContract; } set { _vmContract = Guard.Against.Null(value, nameof(_vmContract)); } }
        public Project Project { get { return _project; } set { _project = Guard.Against.Null(value, nameof(_project)); } }
        public FysiekeServer? FysiekeServer { get { return _server; } set { Guard.Against.Null(_server, nameof(_server)); } }

        public VirtualMachine(string n, OperatingSystemEnum os, Hardware h, Backup b)
        {
            Name = n;
            OperatingSystem = os;
            Hardware = h;
            BackUp = b;
            Mode = VirtualMachineMode.WAITING_APPROVEMENT;
        }

        public void AddConnection(string FQDN, IPAddress hostname, string username, string password)
        {
            Connection = new VMConnection(FQDN, hostname, username, password);
            Mode = VirtualMachineMode.READY;
        }



    }
}
