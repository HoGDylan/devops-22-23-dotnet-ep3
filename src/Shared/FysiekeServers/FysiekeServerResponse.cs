using System;
using System.Collections.Generic;

namespace Shared.FysiekeServers
{
    public static class FysiekeServerResponse
    {
        public class GetIndex
        {
            public List<FysiekeServerDto.Index> FysiekeServers { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public FysiekeServerDto.Detail FysiekeServer { get; set; }
        }

        public class Delete
        {
        }

        public class Create
        {
            public int FysiekeServerId { get; set; }
            public Uri UploadUri { get; set; }
        }

        public class Edit
        {
            public int FysiekeServerId { get; set; }
        }
    }
}
