using Microsoft.AspNetCore.Components;
using Shared.FysiekeServers;
using Smart.Blazor;
using UnlockedData.Chartist.Blazor;
using UnlockedData.Chartist.Blazor.Core.Data;

namespace Client.Rapportage;

partial class Details
{
    string[] chartFilter = new string[] { "Per Uur", "Dagelijks", "Wekenlijks", "Maandenlijks" };
    [Parameter] public int Id { get; set; }
    public string Model { get; set; }
    [Inject] IFysiekeServerService Service { get; set; }
    public string KeuzeChart { get; set; }
    private FysiekeServerDto.Detail server_response;
    ExtendedChartData _lineData { get; set; }
    LineOptions _defaultOptions { get; set; } = new();
    protected override async Task OnInitializedAsync()
    {
        FysiekeServerRequest.Detail request = new FysiekeServerRequest.Detail() { ServerId = Id };
        var response = await Service.GetDetailsAsync(request);
        server_response = response.Server;

        
    }

    public static void MakeDynamicChart()
    {
   
       

    }

}