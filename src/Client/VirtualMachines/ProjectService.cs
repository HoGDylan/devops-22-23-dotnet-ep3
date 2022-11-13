using Client.Extentions;
using Shared.Projects;
using System.Net;

namespace Client.VirtualMachines
{
    private readonly HttpClient client;
    private const string endpoint = "api/project";
    public class ProjectService : IProjectService
    {
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
            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<ProjectResponse.All>($"{endpoint}?{queryParameters}");
            return response;
        }
    }
}
