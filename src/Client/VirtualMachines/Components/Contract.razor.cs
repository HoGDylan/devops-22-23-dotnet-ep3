using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines.Components;

partial class Contract
{
    [Parameter] public VirtualMachineDto.Index Vm { get; set; }

}
