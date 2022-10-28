using Ardalis.GuardClauses;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public class VMContract : Entity
    {
        private int _customerId;
        private int _vmId;
        private int _beheerderId;
        private DateTime _startDate;
        private DateTime _endDate;


        public int Id { get; set; }
        public int CustomerId { get { return _customerId; } set { Guard.Against.NegativeOrZero(_customerId, nameof(_customerId)); } }
        public int VMId { get { return _vmId; } set { Guard.Against.NegativeOrZero(_vmId, nameof(_vmId)); }}
        //public int BeheerderId { get { return _beheerderId; }  set { Guard.Against.NegativeOrZero(_beheerderId, nameof(_beheerderId)); } }
        public DateTime StartDate { get { return _startDate; } set { Guard.Against.Null(_startDate, nameof(_startDate)); } }
        public DateTime EndDate { get { return _endDate; } set { Guard.Against.Null(_endDate, nameof(_endDate)) ; } }


        public VMContract(int c_id, int vm_id,/* int beh_id,*/ DateTime start_d, DateTime end_d)
        {
            this.CustomerId = c_id;
            this.VMId = vm_id;
            //this.BeheerderId = beh_id;
            this.StartDate = start_d;
            this.EndDate = end_d;         
        }
    }
}
