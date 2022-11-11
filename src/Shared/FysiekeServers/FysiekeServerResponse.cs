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
            public FysiekeServerDto.Detail Server { get; set; } // gedetailleerd overzicht van server zijn hardware in gebruik + niet, + serveradress
            public List<VirtualMachineDto.Detail> VirtualMachines { get; set; } //overzicht VM met status | naam | project | hardware | contract
        }
        
        public class Launched
        {
            public VirtualMachineDto.Detail VirtualMachine { get; set; } // VirtualMachine heeft een VMConnection gekregen en wordt teruggeven.
        }
    }
}
