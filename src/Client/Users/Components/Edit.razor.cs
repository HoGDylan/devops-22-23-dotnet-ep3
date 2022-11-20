using Microsoft.AspNetCore.Components;
using Shared.Projects;
using Shared.Users;

namespace Client.Users.Components;

partial class Edit
{
    [Parameter] public int Id { get; set; }
    private KlantDto.Mutate model = new();
    [Inject] public IUserService UserService { get; set; }
}
