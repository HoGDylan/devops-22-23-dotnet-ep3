namespace Shared.VirtualMachines
{
    public static class VirtualMachineRequest
    {
        public class GetIndex
        {
            public string SearchTerm { get; set; }

        }

        public class GetDetail
        {
            public int VirtualMachineId { get; set; }
        }

        public class Delete
        {
            public int VirtualMachineId { get; set; }
        }

        public class Create
        {
            public VirtualMachineDto.Mutate VirtualMachine { get; set; }
        }

        public class Edit
        {
            public int VirtualMachineId { get; set; }
            public VirtualMachineDto.Mutate VirtualMachine { get; set; }
        }
    }
}
