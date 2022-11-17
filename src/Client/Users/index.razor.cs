using Microsoft.AspNetCore.Components;
using Shared.Users;

namespace Client.Users;

public partial class Index
{
    [Inject] public IUserService UserService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    private List<KlantDto.Index> Klanten { get; set; }

    protected override async Task OnInitializedAsync()
    {
        UserRequest.AllKlantenIndex request = new();

        var response = await UserService.GetAllKlanten(request);
        Klanten = response.Klanten;
    }

    public void Toast()
    {
        
    }
}
