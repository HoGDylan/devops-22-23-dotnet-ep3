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
using Microsoft.JSInterop;
using Shared.Servers;
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
        private ChartJs.Blazor.Chart _chart;
        private bool Loading = false;
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            await getVirtualmachine();
            //_data = vm.Statistics.GetFakeStatisticsPerHour();
            ConfigureLineConfig();
            Loading = false;
        }

        private async Task getVirtualmachine()
        {

            var response = await VirtualMachineService.RapporteringAsync(new VirtualMachineRequest.GetDetail { VirtualMachineId = Id });
            vm = response.VirtualMachine;
            Console.WriteLine(vm.Statistics.Hardware is null);
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
                    Text = $"Grafiek Virtualmachine\n{vm.Name}"
                },
                Tooltips = new Tooltips
                {
                    Mode = InteractionMode.Nearest,
                    Intersect = true
                },
                Hover = new Hover
                {
                    Mode = InteractionMode.Nearest,
                    Intersect = true
                },
            };
            DataInDataset();
            instellenAxes();
            _chart.Config = LineConf;
            _chart.Update();
        }


        private void DataInDataset()
        {
            var cpuData = new List<int>();
            var memoryData = new List<int>();
            var storageData = new List<int>();

            _data.ForEach(data =>
        {
             LineConf.Data.Labels.Add(data.Tick.ToString());
             cpuData.Add(data.HardWareInUse.Amount_vCPU);
             memoryData.Add(data.HardWareInUse.Memory);
             storageData.Add(data.HardWareInUse.Storage);
        });
            IDataset<int> cpuDataset = new LineDataset<int>() { Label = "vCpu", BackgroundColor= "#F01010", Fill =FillingMode.Origin };
            IDataset<int> memoryDataset = new LineDataset<int>() { Label = "Memory", BackgroundColor = "#32F010", Fill = FillingMode.Origin };
            IDataset<int> storageDataset = new LineDataset<int>() { Label = "Storage", BackgroundColor = "#1046F0", Fill = FillingMode.Origin };
            LineConf.Data.Datasets.Add(cpuDataset);
            LineConf.Data.Datasets.Add(memoryDataset);
            LineConf.Data.Datasets.Add(storageDataset);
        }

        private void instellenAxes()
        {
            LineConf.Options.Scales = new Scales
            {
                XAxes = new List<CartesianAxis>
                {
                    new CategoryAxis
                    {
                        ScaleLabel = new ScaleLabel
                        {
                            LabelString = "Month"
                        }
                    }
                },
                YAxes = new List<CartesianAxis>
                {
                    new LinearCartesianAxis
                    {
                        ScaleLabel = new ScaleLabel
                        {
                            LabelString = "Value"
                        }
                    }
                }
            };
        }
    }
}


