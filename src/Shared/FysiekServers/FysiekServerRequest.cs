namespace Shared.FysiekServers
{
    public static class FysiekServerRequest
    {
        public class GetIndex
        {
            public string SearchTerm { get; set; }

        }

        public class GetDetail
        {
            public int FysiekServerId { get; set; }
        }

        public class Delete
        {
            public int FysiekServerId { get; set; }
        }

        public class Create
        {
            public FysiekServerDto.Mutate FysiekServer { get; set; }
        }

        public class Edit
        {
            public int FysiekServerId { get; set; }
            public FysiekServerDto.Mutate FysiekServer { get; set; }
        }
    }
}
