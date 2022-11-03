using System;
using System.Collections.Generic;

namespace Shared.FysiekServers
{
    public static class FysiekServerResponse
    {
        public class GetIndex
        {
            public List<FysiekServerDto.Index> FysiekServers { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public FysiekServerDto.Detail FysiekServer { get; set; }
        }

        public class Delete
        {
        }

        public class Create
        {
            public int FysiekServerId { get; set; }
            public Uri UploadUri { get; set; }
        }

        public class Edit
        {
            public int FysiekServerId { get; set; }
        }
    }
}
