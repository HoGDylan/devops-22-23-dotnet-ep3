using Client.Extentions;
using Client.Infrastructure;
using Shared.FysiekeServers;
using System.Globalization;
using System.Net.Http.Json;

namespace Client.Servers
{
    public class FysiekeServerService : IFysiekeServerService
    {
        private readonly HttpClient _httpClient;

        private const string endpoint = "api/fysiekeserver";

        public FysiekeServerService(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;

        }

        public async Task<FysiekeServerResponse.GetIndex> GetIndexAsync(FysiekeServerRequest.GetIndex request)
        {
            //var queryParameters = request.GetQueryString();
            var response = await _httpClient.GetFromJsonAsync<FysiekeServerResponse.GetIndex>($"{endpoint}");
            return response;
        }

        public Task<FysiekeServerResponse.GetDetail> GetDetailAsync(FysiekeServerRequest.GetDetail request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(FysiekeServerRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.Create> CreateAsync(FysiekeServerRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.Edit> EditAsync(FysiekeServerRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.Available> GetAvailableServersByHardWareAsync(FysiekeServerRequest.Order request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.Launched> DeployVirtualMachine(FysiekeServerRequest.Approve request)
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
