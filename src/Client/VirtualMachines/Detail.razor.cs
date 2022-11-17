using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;
using Client.VirtualMachines.Components;
using Domain.VirtualMachines.VirtualMachine;
using Client.Shared;

namespace Client.VirtualMachines;

public partial class Detail
{
    public VirtualMachineDto.Detail Virtualmachine { get; set; }
    [Inject] public IVirtualMachineService vmService { get; set; }
    [Inject] NavigationManager NavMan { get; set; }
    [Parameter] public int Id { get; set; }


    protected override async Task OnInitializedAsync()
    {
        var request = new VirtualMachineRequest.GetDetail();
        request.VirtualMachineId = Id;
        await base.OnInitializedAsync();
        var vm_request = await vmService.GetDetailAsync(request);
        Virtualmachine = vm_request.VirtualMachine;
        Console.WriteLine(Virtualmachine.Hardware.ToString());
    }

    private void NavigateToKlant()
    {
        NavMan.NavigateTo($"/virtualmachine{Virtualmachine.Id}/Klant");
    }

    public void NavigateToReport()
    {
        NavMan.NavigateTo($"virtualmachine/rapport/{Virtualmachine.Id}");
    }
}
