    using Domain.Common;
    using Domain.Projecten;
    using Shared.Projects;


    namespace Services.Projects
    {
        public class FakeProjectService : IProjectService
        {
            private List<Project> _projects = new();

            public FakeProjectService()
            {
                var projectFaker = new ProjectFaker();
                _projects = projectFaker.Generate(15);
            }


            public async Task<ProjectResponse.Create> CreateAsync(ProjectRequest.Create request)
            {
                await Task.Delay(100);

                ProjectResponse.Create response = new();

                var project = request.Project;
                var customer = request.Project.Klant;

                int id = _projects.Max(x => x.Id) + 1;

                Project p = new Project(project.Name) { Id = id, Klant = customer };
                _projects.Add(p);



                response.ProjectId = id;

                return response;
            }



            public async Task DeleteAsync(ProjectRequest.Delete request)
            {
                await Task.Delay(100);

                var proj = _projects.SingleOrDefault(x => x.Id == request.ProjectId);
                _projects.Remove(proj);
            }

            public async Task<ProjectResponse.Edit> EditAsync(ProjectRequest.Edit request)
            {
                await Task.Delay(100);
                ProjectResponse.Edit response = new();

                var proj = _projects.SingleOrDefault(x => x.Id == request.ProjectId);

                if (proj == null)
                {
                    response.ProjectId = -1;
                    return response;
                }


                proj.Name = request.Project.Name;
                proj.Klant = request.Project.Klant;

                response.ProjectId = proj.Id;
                return response;


            }

            public async Task<ProjectResponse.Detail> GetDetailAsync(ProjectRequest.Detail request)
            {
                await Task.Delay(100);
                ProjectResponse.Detail response = new();

                response.Project = _projects.Select(e => new ProjectDto.Detail
                {
                    Id = e.Id,
                    Klant = e.Klant,
                    Name = e.Name,
                    VirtualMachines = e.VirtualMachines
                }).SingleOrDefault(e => e.Id == request.ProjectId);

                return response;
            }

            public async Task<ProjectResponse.All> GetIndexAsync(ProjectRequest.All request)
            {

                await Task.Delay(100);

                ProjectResponse.All response = new();
                List<Project> projects;

                if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    projects  =  _projects.FindAll(e => e.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) || e.Klant.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    projects = _projects;
                }

                response.Total = projects.Count();
                response.Projects = projects.Select(x => new ProjectDto.Index
                {
                    Id = x.Id,
                    Name = x.Name,
                    Klant = x.Klant
                    
                }).ToList();

                return response;
               }
            }
        }

