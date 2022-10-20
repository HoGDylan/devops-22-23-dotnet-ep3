using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server
{
    public class FysiekeServer
    {
        public int Id { get; set; }
        public String Naam { get; set; }
        public String ServerAddress { get; set; }

        public int MemoryCapacity { get; set; }
        public int MemoryAvailable { get; set; }

        public int StorageCapacity { get; set; }
        public int StorageAvailable { get; set; }

        public int VCPUsAvailable { get; set; }
        public int VCPUsCapacity { get; set; }



        public FysiekeServer(string naam, string s_adres, int mem_cap, int mem_av, int stor_cap, int stor_av, int vCPU_cap, int vCPU_av)
        {
            this.Naam = Guard.Against.NullOrEmpty(naam, nameof(naam));
            this.ServerAddress = Guard.Against.NullOrEmpty(s_adres, nameof(s_adres));
            this.MemoryCapacity = Guard.Against.NegativeOrZero(mem_cap, nameof(mem_cap));
            this.MemoryAvailable = Guard.Against.Negative(mem_av, nameof(mem_av));
            this.StorageCapacity = Guard.Against.NegativeOrZero(stor_cap, nameof(stor_cap));
            this.StorageAvailable = Guard.Against.Negative(stor_av, nameof(stor_av));
            this.VCPUsCapacity = Guard.Against.NegativeOrZero(vCPU_cap, nameof(vCPU_cap));
            this.VCPUsAvailable = Guard.Against.Negative(vCPU_av, nameof(vCPU_av));
        }

    }
}
