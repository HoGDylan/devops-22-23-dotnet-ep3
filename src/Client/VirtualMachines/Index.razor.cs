using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Shared.Projects;
using Client.VirtualMachines.Components;


namespace Client.VirtualMachines
{
    public partial class Index : IDisposable
    {
        [Inject] public ISidepanelService SidePanel { get; set; }

        [Inject] public IProjectService ProjectService { get; set; }
        private List<ProjectDto.Index> _projects;
        private bool showVms = false;

        public void ExpandProject()
        {
            
            if (showVms)
            {
                showVms = false;
            }
            else
            {
                showVms = true;
            }
            
        }

        protected override async Task OnInitializedAsync()
        {

            ProjectRequest.All request = new();

            var response = await ProjectService.GetIndexAsync(request);
            _projects = response.Projects;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}