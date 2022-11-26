using Bogus;
using Domain.Common;
using Domain.Server;
using Shared.Servers;
using Shared.VirtualMachines;
using System.Linq;

namespace Services.Server
{
    public class FakeServerService : IFysiekeServerService
    {


        private List<Domain.Server.FysiekeServer> _servers;

        public FakeServerService()
        {
            _servers = new FysiekeServerFaker().Generate(3);
        }


        public Task<FysiekeServerResponse.Available> GetAvailableServersByHardWareAsync(FysiekeServerRequest.Order request)
        {
            throw new NotImplementedException();
        }

        public async Task<FysiekeServerResponse.Details> GetDetailsAsync(FysiekeServerRequest.Detail request)
        {
            FysiekeServerResponse.Details response = new();
            response.Server = new FysiekeServerDto.Detail();


            if (_servers.Any(e => e.Id == request.ServerId))
            {
                List<VirtualMachineDto.Rapportage> vms = _servers.Find(e => e.Id == request.ServerId).VirtualMachines.FindAll(e => e.Connection is not null).Select(e => new VirtualMachineDto.Rapportage() { Id = e.Id, Name = e.Name, Statistics = e.Statistics }).ToList();
                response.Server.Id = request.ServerId;
                response.Server.VirtualMachines = vms;


            }
            else
            {
                response.Server.Id = -1;
            }
            return response;
        }

        public Task<FysiekeServerResponse.Launched> DeployVirtualMachine(FysiekeServerRequest.Approve request)
        {
            throw new NotImplementedException();
        }

        public async Task<FysiekeServerResponse.Available> GetAllServers()
        {
            FysiekeServerResponse.Available respons = new();
            respons.Servers = _servers.Select(s => new FysiekeServerDto.Index
            {
                Id = s.Id,
                Name = s.Naam,
                Hardware = s.HardWare,
                HardWareAvailable = s.HardWareAvailable,
                ServerAddress = s.ServerAddress
            }).ToList();

            respons.Count = _servers.Count();
            return respons;
        }

        public async Task<FysiekeServerResponse.ResourcesAvailable> GetAvailableHardWareOnDate(FysiekeServerRequest.Date date)
        {

            FysiekeServerResponse.ResourcesAvailable response = new();
            response.Servers = new List<FysiekeServerDto.Beschikbaarheid>();

            Dictionary<int, Hardware> output = new();


            foreach (var server in _servers)
            {
                Hardware max = server.HardWare;
                int id = server.Id;

                foreach (var vm in server.VirtualMachines)
                {
                    if (vm.Contract.EndDate < date.FromDate || vm.Contract.StartDate > date.ToDate)
                    {
                        continue;
                    }
                     max = new Hardware(max.Memory - vm.Hardware.Memory, max.Storage - vm.Hardware.Storage, max.Amount_vCPU - vm.Hardware.Amount_vCPU);       
                }

                response.Servers.Add(new FysiekeServerDto.Beschikbaarheid() { Id = server.Id, AvailableHardware = max });

            };
            return response;
        }


        public async Task<FysiekeServerResponse.GraphValues> GetGraphValueForServer(FysiekeServerRequest.Detail request)
        {
            FysiekeServer server = _servers.First(e => e.Id == request.ServerId);

            Dictionary<DateTime, Hardware> inUse = new();

            DateTime today = DateTime.Now;

            foreach (var _vm in server.VirtualMachines)
            {
                if (_vm.Contract.EndDate > today)
                {

                    DateTime end = DateTime.Parse($"{_vm.Contract.EndDate.Day}/{_vm.Contract.EndDate.Month}/{_vm.Contract.EndDate.Year} 00:00");
                    DateTime start;

                    if (_vm.Contract.StartDate <= today)
                    {
                        start = DateTime.Parse($"{today.Day}/{today.Month}/{today.Year} 00:00");
                    }
                    else
                    {
                        start = DateTime.Parse($"{_vm.Contract.StartDate.Day}/{_vm.Contract.StartDate.Month}/{_vm.Contract.StartDate.Year} 00:00");
                    }

                    DateTime value = start;
                    for (int i = 0; i < end.Subtract(start).TotalDays; i++)
                    {
                        if (!inUse.ContainsKey(value))
                        {
                            inUse.Add(value, _vm.Hardware);
                        }
                        else
                        {
                            Hardware current = inUse[value];
                            inUse.Remove(value);
                            inUse.Add(value, new Hardware(current.Memory + _vm.Hardware.Memory, current.Storage + _vm.Hardware.Storage, current.Amount_vCPU + _vm.Hardware.Amount_vCPU));

                        }
                        value.AddDays(1);
                    }
                }
            }
            return new FysiekeServerResponse.GraphValues() { GraphData = inUse };
        }
    }
}