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
    }
}
