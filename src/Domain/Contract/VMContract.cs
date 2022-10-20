using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public class VMContract
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VMId { get; set; }
        public int BeheerderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public VMContract(int c_id, int vm_id, int beh_id, DateTime start_d, DateTime end_d)
        {
            CustomerId = Guard.Against.NegativeOrZero(c_id, nameof(c_id));
            VMId = Guard.Against.NegativeOrZero(vm_id, nameof(vm_id));
            BeheerderId = Guard.Against.NegativeOrZero(beh_id, nameof(beh_id));
            StartDate = Guard.Against.Null(start_d, nameof(start_d));
            EndDate = Guard.Against.Null(end_d, nameof(end_d));
        }
    }
}
