using Shared.VirtualMachines;

namespace Shared.FysiekeServers
{
    public static class FysiekeServerResponse
    {

        public class Available
        {
            public List<FysiekeServerDto.Index> Servers { get; set; }
            public int Count { get; set; }

        }

        public class Details
        {
            public FysiekeServerDto.Detail Server { get; set; } 
        }
        
        public class Launched
        {
            public VirtualMachineDto.Detail VirtualMachine { get; set; } // VirtualMachine heeft een VMConnection gekregen en wordt teruggeven.
        }
    }
}
