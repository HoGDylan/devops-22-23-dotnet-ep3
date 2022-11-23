using Microsoft.AspNetCore.Components;
using Shared.Users;

namespace Client.Users;

public partial class Details
{
    public bool Loading = false;
    public bool Edit = false;
    public bool Intern = false;
    private KlantDto.Detail Klant;
    [Parameter] public int Id { get; set; }
    [Inject] public IUserService UserService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetKlantAsync();
        
    }

    private async Task GetKlantAsync()
    {
        Loading = true;
        var request = new UserRequest.DetailKlant();
        request.KlantId = Id;
        var response = await UserService.GetDetailKlant(request);
        Klant = response.Klant;
        if (Klant.Opleiding is not null)
        {
            Intern = true;
        }
        Console.WriteLine(Klant.Projects.Count()==0);
        Loading = false;
    }
    public async void KlantChangedAsync()
    {
        if(!Edit)
        {

            GetKlantAsync().Wait();
        }
    }
}
