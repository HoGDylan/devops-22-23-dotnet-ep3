using Domain.Projecten;
using Microsoft.AspNetCore.Components;
using Shared.Projects;
using Shared.VirtualMachines;

namespace Client.VirtualMachines.Components;

partial class Algemeen
{
    private ProjectDto.Index project;
    private VirtualMachineDto.Detail vm;
    [Parameter] public int Id { get; set; }
    [Inject] VirtualMachineService VirtualMachineService { get; set; }
    [Inject] NavigationManager NavMan { get; set; }

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
    private void NavigateToKlant()
    {
        NavMan.NavigateTo($"/virtualmachine{Id}/Klant");
    }
}
