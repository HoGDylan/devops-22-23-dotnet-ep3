using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines;

public partial class Index
{
    [Inject] public IVirtualMachineService VirtualMachineService { get; set; }

    private List<VirtualMachineDto.Index> _vms;
    private int _total;


    protected override async Task OnInitializedAsync()
    {
        VirtualMachineRequest.GetIndex request = new();
/*
         List<VirtualMachineResponse.GetIndex> res = await VirtualMachineService.GetIndexAsync(request);
        _vms = res.VirtualMachines;
        _total = res.TotalAmount;
*/
    }

}
