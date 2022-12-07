using System;
using System.Collections.Generic;

namespace Shared.Projecten
{
    public static class ProjectenResponse
    {
        public class GetIndex
        {
            public List<ProjectenDto.Index> Projectens { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public ProjectenDto.Detail Projecten { get; set; }
        }

        public class Delete
        {
        }

        public class Create
        {
            public int ProjectenId { get; set; }
            public Uri UploadUri { get; set; }
        }

        public class Edit
        {
            public int ProjectenId { get; set; }
        }
    }
}
