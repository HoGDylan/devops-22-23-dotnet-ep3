using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines;

public partial class Index
{
    [Inject] public IVirtualMachineService VirtualMachineService { get; set; }

    private List<VirtualMachineDto.Index> virtualMachines;
    private int _total;


    protected override async Task OnInitializedAsync()
    {
        VirtualMachineRequest.GetIndex request = new();

        /* List<VirtualMachineResponse.GetIndex> response = await VirtualMachineService.GetIndexAsync(request);
        virtualMachines = response.VirtualMachines;
        _total = response.TotalAmount;*/

    }

}

