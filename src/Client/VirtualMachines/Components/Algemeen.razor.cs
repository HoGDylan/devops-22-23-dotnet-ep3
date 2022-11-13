using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines.Components;

partial class Algemeen
{
    [Parameter] public VirtualMachineDto.Detail Vm { get; set; }



}
