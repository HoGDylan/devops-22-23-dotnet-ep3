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

        private int _memory;
        private int _storage;
        private int _amountVCPU;



        public int Memory {
            get { return _memory; }
            set { Guard.Against.NegativeOrZero(_memory, nameof(_memory)); } 
        }       
        public int Storage
        {
            get { return _storage; }
            set { Guard.Against.NegativeOrZero(_storage, nameof(_storage)); }
        }
        public int Amount_vCPU {
            get { return _amountVCPU; }
            set { Guard.Against.NegativeOrZero(_amountVCPU, nameof(_amountVCPU)); }
        }
   
        //Bandwidth? Gaan we hier rekening meehouden?


        public Hardware(int m, int s, int a_vCPU)
        {
            this.Memory = m;
            this.Storage = s;
            this.Amount_vCPU = a_vCPU;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Memory;
            yield return Storage;
            yield return Amount_vCPU;
        }

    }
}
