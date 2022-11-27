using ChartJs.Blazor;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Common.Handlers;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.Util;
using Domain.Statistics.Datapoints;
using Domain.VirtualMachines.Statistics;
using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;
using System.Data;
using System.Drawing;
using Xamarin.Forms.Internals;

namespace Client.Servers.Component
{
    public partial class Grafiek
    {
        [Inject] IVirtualMachineService VirtualMachineService { get; set; }
        [Parameter] public int Id { get; set; }
        private LineConfig _config;

        private Dictionary<DateTime, DataPoint> _data = new();
        private VirtualMachineDto.Rapportage vm;

        private Chart _chart;

        private bool Loading = false;
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            await getVirtualmachine();
            _data = vm.Statistics.GetFakeStatistics(StatisticsPeriod.DAILY);
           
            ConfigureLineConfig();
            Loading = false;
        }

        private async Task getVirtualmachine()
        {
            var response = await VirtualMachineService.RapporteringAsync(new VirtualMachineRequest.GetDetail { VirtualMachineId = Id });
            vm = response.VirtualMachine;
        }

        private void ConfigureLineConfig()
        {

            _config = new LineConfig
            {
                Options = new LineOptions
                {
                    //https://www.chartjs.org/docs/latest/developers/plugins.html <- heb ik nodig, maar vind nergens alternatief voor c#

                    Legend = new Legend()
                    {
                        Labels = new LegendLabels()
                        {
                            Padding = 10,
                        }
                    },
                    Responsive = true,
                    
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
                    Scales = new Scales
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
                    },
                    
                }
            };
            AddLabels();
            addDataToDataSet();
        }


        public void addDataToDataSet()
        {

            IDataset<int> memory = new LineDataset<int>()
            {
                Label = "RAM (GB)",
                BorderColor = ColorUtil.FromDrawingColor(Color.DarkRed),
            };
            IDataset<int> storage = new LineDataset<int>()
            {
                Label = "Opslag (GB)",
                BorderColor = ColorUtil.FromDrawingColor(Color.DarkBlue),
            }; IDataset<int> cores = new LineDataset<int>()
            {
                Label = "#Cores",
                BorderColor = ColorUtil.FromDrawingColor(Color.DarkGreen),
            };

            _config.Data.Datasets.Add(memory);
            _config.Data.Datasets.Add(storage);
            _config.Data.Datasets.Add(cores);

           
            foreach (LineDataset<int> dataSet in _config.Data.Datasets)
            {
                switch (dataSet.Label)
                {
                    case "RAM (GB)":
                        {
                            dataSet.AddRange(_data.Select(e => (e.Value.HardWareInUse.Memory / 1000)));
                            break;
                        }
                    case "Opslag (GB)":
                        {
                            dataSet.AddRange(_data.Select(e => e.Value.HardWareInUse.Storage / 1000));
                            break;
                        }
                    case "#Cores": {
                            dataSet.AddRange(_data.Select(e => e.Value.HardWareInUse.Amount_vCPU));
                            break;
                        }

                }
            }
        }

        private void AddLabels()
        {

            DateTime min = _data.Keys.First();
            DateTime max = _data.Keys.Last();

            int difference = max.Subtract(min).Days;
            _config.Data.Labels.Add(min.ToString("dd/MM/yyy"));

            if (difference <= 8)
            {
                for(int i = 1; i <= difference; i++)
                {
                    min = min.AddDays(1);
                    _config.Data.Labels.Add(min.ToString("dd/MM/yyy"));
                }
            }
            else
            {
                for (int i = 1; i <= 8; i++)
                {
                    min = min.AddDays(i % 2 == 0 ? (int)Math.Floor(difference / 8.0) : (int)Math.Ceiling(difference / 8.0));
                    _config.Data.Labels.Add(min.ToString("dd/MM/yyy"));
                }
            }


            _config.Data.Labels.Add(max.ToString("dd/MM/yyyy"));

        }
    }
}


