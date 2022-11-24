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
using Smart.Blazor;
using System.Collections.Generic;
using System.Data;

namespace Client.Rapportage.Component;

partial class Grafiek
{
    [Parameter] public int Id { get; set; }
    [Inject] public Statistic stats { get; set; }
    private LineConfig _lineConfig;
    private List<DataPoint> _data = new();
    private VirtualMachineService service { get; set; }

    protected override void OnInitialized()
    {
        getVirtualmachine();
        _data = stats.GetFakeStatisticsPerHour();
        
        ConfigureLineConfig();
    }

    private async Task getVirtualmachine()
    {
        /*var response = await service.*/
    }

    private void ConfigureLineConfig()
    {
        _lineConfig = new LineConfig();

        _lineConfig.Options = new LineOptions
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
            cpuData.Add(data.HardWareInUse.Amount_vCPU);
            memoryData.Add(data.HardWareInUse.Memory);
            storageData.Add(data.HardWareInUse.Storage);
        });
        IDataset<int> cpuDataset = new LineDataset<int>(cpuData){ Label = "vCpu", BackgroundColor = "DE1212"};
        IDataset<int> memoryDataset = new LineDataset<int>(memoryData) { Label = "Memory" , BackgroundColor= "125FDE" };
        IDataset<int> storageDataset = new LineDataset<int>(storageData) { Label = "Storage", BackgroundColor = "12DE18" };
        _lineConfig.Data.Datasets.Add(cpuDataset);
        _lineConfig.Data.Datasets.Add(memoryDataset);
        _lineConfig.Data.Datasets.Add(storageDataset);
    }
}