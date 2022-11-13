using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;

namespace Client.VirtualMachines;

public partial class Detail
{

    private VirtualMachineDto.Detail? _vm;
    [Inject] public IVirtualMachineService _vmService { get; set; } = default!;
    [Parameter] public int ProductId { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
       // _vm = await _vmService.GetDetailAsync(ProductId);
    }
}
