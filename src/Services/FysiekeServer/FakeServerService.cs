using Bogus;
using Domain.Server;
using Shared.FysiekeServers;

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
            throw new NotImplementedException();
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
