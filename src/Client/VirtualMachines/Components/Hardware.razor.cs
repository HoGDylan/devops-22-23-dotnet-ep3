using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines.Components;

partial class Hardware
{
    [Parameter] public VirtualMachineDto.Index Vm { get; set; }
    [Inject] NavigationManager NavMan { get; set; }

    public void NavigateToReport()
    {
        NavMan.NavigateTo($"virtualmachine/rapport/{Vm.Id}");
    }
}
