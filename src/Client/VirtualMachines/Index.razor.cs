using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Shared.Projects;
using Client.VirtualMachines.Components;
using Microsoft.AspNetCore.Components.Web;
using JetBrains.Annotations;


namespace Client.VirtualMachines
{
    public partial class Index 
    {
        [Inject] public ISidepanelService SidePanel { get; set; }

        [Inject] public IProjectService ProjectService { get; set; }

        private List<ProjectDto.Index> _projects;

        private Dictionary<int, ProjectDto.Detail> _details = new Dictionary<int, ProjectDto.Detail>();

        protected override async Task OnInitializedAsync()
        {

            ProjectRequest.All request = new();

            var response = await ProjectService.GetIndexAsync(request);
            _projects = response.Projects;
            

        }


        public async Task GetVirtualMachines(int id)
        {
                ProjectRequest.Detail request = new();

                request.ProjectId = id;

                var response = await ProjectService.GetDetailAsync(request);
                ProjectDto.Detail resp = new ProjectDto.Detail()
                {
                    Id = response.Project.Id,
                    Klant = response.Project.Klant,
                    Name = response.Project.Name,
                    VirtualMachines = response.Project.VirtualMachines
                };


                Console.WriteLine("--DEBUG--");
                Console.WriteLine("Received: " + resp.Id);
                Console.WriteLine("vm count: " + resp.VirtualMachines.Count());
                Console.WriteLine("customer name: " + resp.Klant.Name);



                _details.Add(id, resp);

            }            

        }   
}