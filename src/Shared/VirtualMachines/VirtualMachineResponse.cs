namespace Shared.VirtualMachines
{
    public static class VirtualMachineResponse
    {
        public class GetIndex
        {
            public List<VirtualMachineDto.Index> VirtualMachines { get; set; } = new();
            public int TotalAmount { get; set; }

        }

        public class GetDetail
        {
            public VirtualMachineDto.Detail VirtualMachine { get; set; }
        }

        public class Delete
        {

        }

        public class Create
        {
            public int VM_Id { get; set; }
        }

        public class Edit
        {
            public int VM_Id { get; set; }
        }

        public class Rapport
        {
            public VirtualMachineDto.Rapportage VirtualMachine { get; set; }
        }


    }
}