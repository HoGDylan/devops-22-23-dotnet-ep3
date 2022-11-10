using Shared.VirtualMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Projects
{
    public interface IProjectService
    {
        Task<ProjectResponse.All> GetIndexAsync(ProjectRequest.All request); // can be used for searching on name 
        Task<ProjectResponse.Detail> GetDetailAsync(ProjectRequest.Detail request); // can be used to select a project and send ID as param
        Task DeleteAsync(ProjectRequest.Delete request);
        Task<ProjectResponse.Create> CreateAsync(ProjectRequest.Create request);
        Task<ProjectResponse.Edit> EditAsync(ProjectRequest.Edit request);
    }
}
