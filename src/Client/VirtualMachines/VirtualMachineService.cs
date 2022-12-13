using Client.Extentions;
using Shared.Projecten;
using Shared.VirtualMachines;
using System.Net.Http.Json;

namespace Client.VirtualMachines
{
    
    public class VirtualMachineService : IVirtualMachineService
    {

        private readonly HttpClient client;
        private const string endpoint = "api/virtualmachine";
        public VirtualMachineService(HttpClient client)
        {
            this.client = client;
        }

        public Task<VirtualMachineResponse.Create> CreateAsync(VirtualMachineRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(VirtualMachineRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<VirtualMachineResponse.Edit> EditAsync(VirtualMachineRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public async Task<VirtualMachineResponse.GetDetail> GetDetailAsync(VirtualMachineRequest.GetDetail request)
        {
            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<VirtualMachineResponse.GetDetail>($"{endpoint}?{queryParameters}");
            return response;
        }

        public async Task<ProjectenResponse.GetIndex> GetIndexAsync(ProjectenResponse.GetIndex request)
        {
            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<ProjectenResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;
        }

        public Task<VirtualMachineResponse.GetIndex> GetIndexAsync(VirtualMachineRequest.GetIndex request)
        {
            throw new NotImplementedException();
        }

        public async Task<VirtualMachineResponse.Rapport> RapporteringAsync(VirtualMachineRequest.GetDetail request)
        {
            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<VirtualMachineResponse.Rapport>($"{endpoint}?{queryParameters}");
            return response;
        }
    }
}
