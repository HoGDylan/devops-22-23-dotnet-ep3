using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Projects;
using System.Threading.Tasks;

namespace Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectenService)
        {
            this.projectService = projectenService;
        }

        //[Authorize(Roles = "Klant")]
        [HttpGet, AllowAnonymous]
        public Task<ProjectResponse.All> GetIndexAsync([FromQuery] ProjectRequest.All request)
        {
            return projectService.GetIndexAsync(request);
        }

        //[Authorize(Roles = "Klant")]
        [HttpGet("{ProjectenId}"), AllowAnonymous]
        public Task<ProjectResponse.Detail> GetDetailAsync([FromRoute] ProjectRequest.Detail request)
        {
            return projectService.GetDetailAsync(request);
        }

        [Authorize(Roles = "BeheerderBeheren")]
        [HttpDelete("{ProjectenId}")]
        public Task DeleteAsync([FromRoute] ProjectRequest.Delete request)
        {
            return projectService.DeleteAsync(request);
        }

        [Authorize(Roles = "BeheerderBeheren")]
        [HttpPost]
        public Task<ProjectResponse.Create> CreateAsync([FromBody] ProjectRequest.Create request)
        {
            return projectService.CreateAsync(request);
        }

        [Authorize(Roles = "BeheerderBeheren")]
        [HttpPut]
        public Task<ProjectResponse.Edit> EditAsync([FromBody] ProjectRequest.Edit request)
        {
            return projectService.EditAsync(request);
        }
    }
}