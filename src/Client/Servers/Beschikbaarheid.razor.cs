using Domain.Common;
using Microsoft.AspNetCore.Components;
using Shared.FysiekeServers;

namespace Client.Servers
{
    public partial class Beschikbaarheid
    {
        [Inject] public IFysiekeServerService FysiekeServerService { get; set; }

        private List<FysiekeServerDto.Beschikbaarheid> Servers { get; set; }
        private DateTime Date { get; set; } = DateTime.Now;


        private async Task GetAvailableResources()
        {
            var response = await FysiekeServerService.GetAvailableHardWareOnDate(new FysiekeServerRequest.Date() { OnDate = Date });
            Servers = response.Servers;
        }


    }
}


