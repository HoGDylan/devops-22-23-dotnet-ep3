using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VMContracts
{
    public static class VMContractRequest
    {
        public class GetByDate
        {
            public DateTime Start { get; set; }
            public DateTime? End { get; set; }

        }

        public class GetDetail
        {
            public int Id { get; set; }
        }

        public class Create
        {
            public VMContractDto.Mutate VMContract { get; set; }
        }

        public class Edit
        {
            public int Id { get; set; }

            public VMContractDto.Mutate VMContract { get; set; }
        }

        public class Delete
        {
            public int Id { get; set; }
        }
    }
}