﻿using Client.Extentions;
using Client.Infrastructure;
using Domain.Server;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;

namespace Client.Servers
{
    public class FysiekeServicerService
    {

    }
}
   /* 
    public class FysiekeServerService : IFysiekeServerService
    {
        private readonly HttpClient _httpClient;

        private readonly IHttpClientFactory _IHttpClientFactory;

        private const string endpoint = "api/fysiekeserver";

        public FysiekeServerService(HttpClient _httpClient, IHttpClientFactory _IHttpClientFactory)
        {
            this._httpClient = _httpClient;
            this._IHttpClientFactory = _IHttpClientFactory;


        }

        public async Task<FysiekeServerResponse.GetIndex> GetIndexAsync(FysiekeServerRequest.GetIndex request)
        {
            //var queryParameters = request.GetQueryString();
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var response = await HttpClient.GetFromJsonAsync<FysiekeServerResponse.GetIndex>($"{endpoint}");
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


        public async Task<FysiekeServerResponse.ResourcesAvailable> GetAvailableHardWareOnDate(FysiekeServerRequest.Date date)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var response = await HttpClient.GetFromJsonAsync<FysiekeServerResponse.ResourcesAvailable>($"{endpoint}");
            return response;

        }

        public async Task<FysiekeServerResponse.GraphValues> GetGraphValueForServer(FysiekeServerRequest.GetIndex request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var response = await HttpClient.GetFromJsonAsync<FysiekeServerResponse.GraphValues>($"{endpoint}");
            return response;
        }

    }

}*/
