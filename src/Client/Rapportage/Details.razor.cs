using Microsoft.AspNetCore.Components;
using Shared.FysiekeServers;

namespace Client.Rapportage;

partial class Details
{
    [Parameter] public int Id { get; set; }
    [Inject] IFysiekeServerService Service { get; set; }

    private FysiekeServerDto.Detail server_response;

    protected override async Task OnInitializedAsync()
    {
        FysiekeServerRequest.Detail request = new FysiekeServerRequest.Detail() { ServerId = Id };
        var response = await Service.GetDetailsAsync(request);
        server_response = response.Server;

    }

}