using Ardalis.GuardClauses;
using Bogus.DataSets;
using Domain.Common;
using Domain.Contract;
using Domain.Project;
using Domain.Projecten;
using Domain.Server;
using Domain.Users;

namespace Domain.VirtualMachines
{
    public class VirtualMachine : Entity
    {

        private VMContract _vmContract;


        private string _name;
        private OperatingSystemEnum _operatingSystem;
        private VirtualMachineMode _mode;
        private Klant _gebruiker;
        private Project _project;
        private FysiekeServer? _serverUsing;

        public String Name { get { return _name; } set { Guard.Against.NullOrEmpty(_name, nameof(_name)); } }

        public OperatingSystemEnum OperatingSystem { get { return _operatingSystem; } set { Guard.Against.Null(_operatingSystem, nameof(_operatingSystem)); } }
        public VirtualMachineMode Mode { get { return _mode; } set { Guard.Against.Null(_mode, nameof(_mode)); } }
        public Hardware Hardware { get; set; }
        public VMConnection? Connection { get; set; }
        public Backup BackUp { get; set; }
        public Klant Customer { get { return _gebruiker; } set { Guard.Against.Null(_gebruiker, nameof(_gebruiker)); } }
        public VMContract Contract { get { return _vmContract; } set { Guard.Against.Null(_vmContract, nameof(_vmContract)); } }
        public Project Project { get { return _project; } set { Guard.Against.Null(_project, nameof(_project)); } }
        public FysiekeServer? Server { get { return _serverUsing; } set { Guard.Against.Null(_serverUsing, nameof(_serverUsing)); } }
        
        public VirtualMachine(string n, Project p, OperatingSystemEnum os, Hardware h, Backup b, Klant k, DateTime start, DateTime end)
        { 
            this.Project = p;
            this.Name = n;           /*== null?  $"{os}-{h.Memory}Gb.{p.Name}" : n;*/
            this.OperatingSystem = os;
            this.Hardware = h;
            this.BackUp = b;
            this.Customer = k;
            this.Contract = new VMContract(k.Id, this.Id, start, end);
            this.Mode = VirtualMachineMode.WAITING_APPROVEMENT;
        }

        //when approved, admin can add to server
        public void AddServer(FysiekeServer s)
        {
            this._serverUsing = s;
        }

        //when addedToServer, admin can add connection
        public void AddConnection(string FQDN, string hostname, string username, string password)
        {
            this.Connection = new VMConnection(FQDN, hostname, username, password);
            this.Mode = VirtualMachineMode.READY;
        }

    }
}
