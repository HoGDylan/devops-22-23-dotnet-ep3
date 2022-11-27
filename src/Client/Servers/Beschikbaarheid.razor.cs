using Domain.Common;
using Microsoft.AspNetCore.Components;
using Shared.Servers;

namespace Client.Servers
{
    public partial class Beschikbaarheid
    {
        [Inject] public IFysiekeServerService FysiekeServerService { get; set; }

        private List<FysiekeServerDto.Beschikbaarheid> Servers { get; set; }
        private DateTime DateStart { get; set; } = DateTime.Now;
        private DateTime DateEnd { get; set; } = DateTime.Now;


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetAvailableResources();
        }

        private async Task GetAvailableResources()
        {
            var response = await FysiekeServerService.GetAvailableHardWareOnDate(new FysiekeServerRequest.Date() { FromDate = DateStart, ToDate = DateEnd });
            Servers = response.Servers;
        }


    }
}


