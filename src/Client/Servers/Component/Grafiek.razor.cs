using ChartJs.Blazor;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using Client.VirtualMachines;
using Domain.Common;
using Domain.Statistics;
using Domain.Statistics.Datapoints;
using Microsoft.AspNetCore.Components;
using Shared.FysiekeServers;
using Shared.VirtualMachines;
using Smart.Blazor;
using System.Collections.Generic;
using System.Data;

namespace Client.Servers.Component
{
public partial class Grafiek 
    {
    [Inject] IVirtualMachineService VirtualMachineService { get; set; }
    [Parameter] public int Id { get; set; }
    public LineConfig LineConf { get; set; }
    private List<DataPoint> _data = new();
    private VirtualMachineDto.Rapportage vm;

    protected override async Task OnInitializedAsync()
    {
        await getVirtualmachine();
        _data = vm.Statistics.GetFakeStatisticsPerHour();
        ConfigureLineConfig();
    }

    private async Task getVirtualmachine()
    {
        var response = await VirtualMachineService.RapporteringAsync(new VirtualMachineRequest.GetDetail { VirtualMachineId = Id });
        vm = response.VirtualMachine;
        Console.WriteLine(vm.Statistics is null);
    }

    private void ConfigureLineConfig()
    {
            LineConf = new LineConfig();

            LineConf.Options = new LineOptions
        {
            Responsive = true,
            Title = new OptionsTitle
            {
                Display = true,
                Text =$"Grafiek Virtualmachine"
            }
        };
        DataInDataset();
            
    }


    private void DataInDataset()
    {
             var cpuData = new List<int>();
             var memoryData = new List<int>();
             var storageData = new List<int>();
            
            _data.ForEach(data =>
        {
            /* cpuData.Add(data.HardWareInUse.Amount_vCPU);
             memoryData.Add(data.HardWareInUse.Memory);
             storageData.Add(data.HardWareInUse.Storage);*/
            cpuData.Add(450);
            memoryData.Add(450);
            storageData.Add(450);
        });
        IDataset<int> cpuDataset = new LineDataset<int>(){ Label = "vCpu"};
        IDataset<int> memoryDataset = new LineDataset<int>() { Label = "Memory"};
        IDataset<int> storageDataset = new LineDataset<int>() { Label = "Storage"};
            LineConf.Data.Datasets.Add(cpuDataset);
            LineConf.Data.Datasets.Add(memoryDataset);
            LineConf.Data.Datasets.Add(storageDataset);
    }
}
}