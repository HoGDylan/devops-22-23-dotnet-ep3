using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VMContracts
{
    public static class VMContractResponse
    {

        public class Index
        {
            public List<VMContractDto.Index> VMContracts { get; set; }
            public int Count { get; set; }

        }

        public class Detail
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public int VMId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
    }
}