using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Domain.Common
{
    public class Hardware : ValueObject
    {

        public int Memory { get; set; }
        public int Storage { get;set; }
        public int Amount_vCPU { get; set; }
   
        //Bandwidth? Gaan we hier rekening meehouden?


        public Hardware(int m, int s, int a_vCPU)
        {
            Memory = Guard.Against.NegativeOrZero(m, nameof(m));
            Storage = Guard.Against.NegativeOrZero(s, nameof(s));
            Amount_vCPU = Guard.Against.NegativeOrZero(a_vCPU, nameof(a_vCPU));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Memory;
            yield return Storage;
            yield return Amount_vCPU;
        }

    }
}
