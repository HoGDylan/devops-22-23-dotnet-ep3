using Client.Extentions;
using Shared.Projecten;
using System.Net;
using System.Net.Http.Json;

namespace Client.VirtualMachines
{
    public class ProjectService : IProjectenService
    {
        private readonly HttpClient client;
        private string endpoint = "api/project";

        public Task<ProjectenResponse.Create> CreateAsync(ProjectenRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProjectenRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectenResponse.Edit> EditAsync(ProjectenRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectenResponse.GetDetail> GetDetailAsync(ProjectenRequest.GetDetail request)
        {
            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<ProjectenResponse.GetDetail>($"{endpoint}?{queryParameters}");
            return response;
        }

        public Task<ProjectenResponse.GetIndex> GetIndexAsync(ProjectenRequest.GetIndex request)
        {
            /*
            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<ProjectResponse.All>($"{endpoint}?{queryParameters}");
            return response;
            */
            return null;
        }
    }
}
