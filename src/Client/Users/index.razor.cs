using Microsoft.AspNetCore.Components;
using Shared.Users;

namespace Client.Users;

public partial class index
{
    [Inject] public IUserService UserService;
}
