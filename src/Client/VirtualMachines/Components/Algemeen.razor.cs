using Domain.Projecten;
using Microsoft.AspNetCore.Components;
using Shared.Projects;
using Shared.VirtualMachines;

namespace Client.VirtualMachines.Components;

partial class Algemeen
{
    private ProjectDto.Index project;
    [Parameter] public VirtualMachineDto.Detail Virtualmachine { get; set; }
    [Inject] NavigationManager NavMan { get; set; }

 /*   private async Task GetVirtualMachineAsync()
    {
        VirtualMachineRequest.GetDetail request = new() { VirtualMachineId = vm.Id };
        var response = await VirtualMachineService.GetDetailAsync(request);
        vm = response.VirtualMachine;
    }*/
    private void NavigateToKlant()
    {
        NavMan.NavigateTo($"/virtualmachine{Virtualmachine.Id}/Klant");
    }
}
