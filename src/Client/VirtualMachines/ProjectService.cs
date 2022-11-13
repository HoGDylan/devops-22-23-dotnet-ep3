using Client.Extentions;
using Shared.Projects;
using System.Net;
using System.Net.Http.Json;

namespace Client.VirtualMachines
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient client;
        private string endpoint = "api/project";

        public Task<ProjectResponse.Create> CreateAsync(ProjectRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProjectRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectResponse.Edit> EditAsync(ProjectRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectResponse.Detail> GetDetailAsync(ProjectRequest.Detail request)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectResponse.All> GetIndexAsync(ProjectRequest.All request)
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
