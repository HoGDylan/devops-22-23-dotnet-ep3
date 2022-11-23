using Bogus;
using Domain.Server;
using Shared.FysiekeServers;
using Shared.VirtualMachines;

namespace Services.FysiekeServer
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

        public Task<FysiekeServerResponse.Details> GetDetailsAsync(FysiekeServerRequest.Detail request)
        {
            FysiekeServerResponse.Details response = new();
            response.Server = new FysiekeServerDto.Detail();

            if (_servers.Any(e => e.Id == request.ServerId))
            {
                List<VirtualMachineDto.Rapportage> vms = _servers.Find(e => e.Id == request.ServerId).VirtualMachines.Select(e => new VirtualMachineDto.Rapportage() { Id = e.Id, Name = e.Name, Statistics = e.Statistics }).ToList();
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
            respons.Servers = _servers.Select(s =>  new FysiekeServerDto.Index{
                Id = s.Id,
                Name = s.Naam,
                Hardware = s.HardWare,
                HardWareAvailable = s.HardWareAvailable,
                ServerAddress = s.ServerAddress
            }).ToList();

            respons.Count = _servers.Count();
            return respons;
        }
    }
}
