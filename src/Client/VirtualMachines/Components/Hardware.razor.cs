using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines.Components;

partial class Hardware
{
    [Parameter] public VirtualMachineDto.Detail vm { get; set; }
    [Inject] NavigationManager NavMan { get; set; }

    public void NavigateToReport()
    {
        NavMan.NavigateTo($"virtualmachine/rapport/{vm.Id}");
    }
/*    private async Task GetVirtualMachineAsync()
    {
        VirtualMachineRequest.GetDetail request = new() { VirtualMachineId = Id };
        var response = await VirtualMachineService.GetDetailAsync(request);
        vm = response.VirtualMachine;
    }*/
}
