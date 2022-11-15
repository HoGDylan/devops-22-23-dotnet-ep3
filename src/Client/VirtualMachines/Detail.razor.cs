using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;
using Client.VirtualMachines.Components;

namespace Client.VirtualMachines;

public partial class Detail
{

    private VirtualMachineDto.Detail? vm;
    [Inject] public IVirtualMachineService vmService { get; set; }
    [Parameter] public int ProductId { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
       // _vm = await _vmService.GetDetailAsync(ProductId);
    }
}
