namespace Shared.FysiekServers
{
    public static class FysiekServerRequest
    {
        public class GetIndex
        {
            public string SearchTerm { get; set; }
            public string Category { get; set; }
            public bool OnlyActiveFysiekServers { get; set; }
            public decimal? MinimumPrice { get; set; }
            public decimal? MaximumPrice { get; set; }
            public int Page { get; set; }
            public int Amount { get; set; } = 25;
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
