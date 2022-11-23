using Microsoft.AspNetCore.Components;
using Shared.FysiekeServers;

namespace Client.Rapportage;

partial class Index 
{
    [Inject] public IFysiekeServerService FysiekeServerService { get; set; }
    private List<FysiekeServerDto.Index> Servers { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var response = await FysiekeServerService.GetAllServers();
        Servers = response.Servers;
    }
}
