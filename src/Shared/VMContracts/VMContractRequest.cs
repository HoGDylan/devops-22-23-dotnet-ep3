namespace Shared.VMContracts
{
    public static class VMContractRequest
    {
        public class GetIndex
        {
            public string SearchTerm { get; set; }
            public string Category { get; set; }
            public bool OnlyActiveVMContracts { get; set; }
            public decimal? MinimumPrice { get; set; }
            public decimal? MaximumPrice { get; set; }
            public int Page { get; set; }
            public int Amount { get; set; } = 25;
        }

        public class GetDetail
        {
            public int VMContractId { get; set; }
        }

        public class Delete
        {
            public int VMContractId { get; set; }
        }

        public class Create
        {
            public VMContractDto.Mutate VMContract { get; set; }
        }

        public class Edit
        {
            public int VMContractId { get; set; }
            public VMContractDto.Mutate VMContract { get; set; }
        }
    }
}
