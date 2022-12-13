namespace Shared.FysiekeServers
{
    public static class FysiekeServerRequest
    {
        public class GetIndex
        {
            public string SearchTerm { get; set; }

        }

        public class GetDetail
        {
            public int FysiekeServerId { get; set; }
        }

        public class Delete
        {
            public int FysiekeServerId { get; set; }
        }

        public class Create
        {
            public FysiekeServerDto.Mutate FysiekeServer { get; set; }
        }

        public class Edit
        {
            public int FysiekeServerId { get; set; }
            public FysiekeServerDto.Mutate FysiekeServer { get; set; }
        }
    }
}
