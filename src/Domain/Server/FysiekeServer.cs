using Ardalis.GuardClauses;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server
{
    public class FysiekeServer : Entity
    {
        public int Id { get; set; }
        public String Naam { get; set; }
        public String ServerAddress { get; set; }

        public Hardware HardWare { get; set; }
        public int MemoryAvailable { get; set; }
        public int StorageAvailable { get; set; }
        public int VCPUsAvailable { get; set; }



        public FysiekeServer(string naam, Hardware hw,  string s_adres, int mem_available, int stor_available, int vCPU_avaiable)
        {
            this.Naam = Guard.Against.NullOrEmpty(naam, nameof(naam));
            this.ServerAddress = Guard.Against.NullOrEmpty(s_adres, nameof(s_adres));
            this.MemoryAvailable = Guard.Against.Negative(mem_available, nameof(mem_available));
            this.StorageAvailable = Guard.Against.Negative(stor_available, nameof(stor_available));
            this.VCPUsAvailable = Guard.Against.Negative(vCPU_avaiable, nameof(vCPU_avaiable));
            this.HardWare = Guard.Against.Null(hw, nameof(hw));
        }

    }
}
