using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines;

partial class Details
{
    private bool isRequestingStop;
    [Parameter] public int Id { get; set; }
    [Inject] IVirtualMachineService virtualMachineService { get; set; }
    [Inject] public NavigationManager navigationManager { get; set; }

    private void RequestStop()
    {
        isRequestingStop = true;
    }

    private void RequestResume()
    {
        isRequestingStop = false;
    }

    private async Task DeleteVMAsync()
    {
        //var request = new ProductRequest.Delete
    }
}