using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines.Components;

partial class Contract
{
    [Parameter] public int Id { get; set; }
    public VirtualMachineDto.Detail vm { get; set; }
    [Inject] VirtualMachineService VirtualMachineService { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await GetVirtualMachineAsync();
    }
    private async Task GetVirtualMachineAsync()
    {
        VirtualMachineRequest.GetDetail request = new() { VirtualMachineId = Id };
        var response = await VirtualMachineService.GetDetailAsync(request);
        vm = response.VirtualMachine;
    }
}
