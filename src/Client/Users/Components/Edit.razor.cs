using Microsoft.AspNetCore.Components;
using Shared.Users;

namespace Client.Users.Components;

partial class Edit
{
    [Parameter] public KlantDto.Detail klant{ get; set; }
    private KlantDto.Mutate model = new();
    [Inject] public IUserService UserService { get; set; }
    
}
