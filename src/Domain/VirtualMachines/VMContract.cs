using Ardalis.GuardClauses;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VirtualMachines
{
    public class VMContract : Entity
    {
        private int _customerId;
        private int _vmId;
        private DateTime _startDate;
        private DateTime _endDate;


        public int Id { get; set; }
        public int CustomerId { get { return _customerId; } set { Guard.Against.NegativeOrZero(_customerId, nameof(_customerId)); } }
        public int VMId { get { return _vmId; } set { Guard.Against.NegativeOrZero(_vmId, nameof(_vmId)); } }
        public DateTime StartDate { get { return _startDate; } set { Guard.Against.Null(_startDate, nameof(_startDate)); } }
        public DateTime EndDate { get { return _endDate; } set { Guard.Against.Null(_endDate, nameof(_endDate)); } }


        public VMContract(int c_id, int vm_id, DateTime start_d, DateTime end_d)
        {
            CustomerId = c_id;
            VMId = vm_id;
            StartDate = start_d;
            EndDate = end_d;
        }
    }
}
