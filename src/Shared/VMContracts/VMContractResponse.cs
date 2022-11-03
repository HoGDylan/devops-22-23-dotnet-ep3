using System;
using System.Collections.Generic;

namespace Shared.VMContracts
{
    public static class VMContractResponse
    {
        public class GetIndex
        {
            public List<VMContractDto.Index> VMContracts { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public VMContractDto.Detail VMContract { get; set; }
        }

        public class Delete
        {
        }

        public class Create
        {
            public int VMContractId { get; set; }
            public Uri UploadUri { get; set; }
        }

        public class Edit
        {
            public int VMContractId { get; set; }
        }
    }
}
