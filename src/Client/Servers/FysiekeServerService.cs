using Shared.Servers;
using System.Globalization;
using System.Net.Http.Json;

namespace Client.Servers
{
    public class FysiekeServerService : IFysiekeServerService
    {
        private readonly HttpClient _httpClient;
        private const string endpoint = "api/fysiekeservers";
        public Task<FysiekeServerResponse.Launched> DeployVirtualMachine(FysiekeServerRequest.Approve request)
        {
            throw new NotImplementedException();
        }

        public async Task<FysiekeServerResponse.Available> GetAllServers()
        {
            var response = await _httpClient.GetFromJsonAsync<FysiekeServerResponse.Available>($"{endpoint}");
            return response;
        }

        public Task<FysiekeServerResponse.Available> GetAvailableServersByHardWareAsync(FysiekeServerRequest.Order request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.Details> GetDetailsAsync(FysiekeServerRequest.Detail request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.ResourcesAvailable> GetAvailableHardWareOnDate(FysiekeServerRequest.Date date)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.GraphValues> GetGraphValueForServer()
        {
            throw new NotImplementedException();
        }
    }
}
