using Microsoft.AspNetCore.Components;
using Shared.Users;

namespace Client.Users.Components;

partial class Edit
{
    public event Action OnKlantChanged;
    [Parameter] public KlantDto.Detail klant{ get; set; }
    private KlantDto.Mutate model = new();
    [Inject] public IUserService UserService { get; set; }
    
    protected override void OnInitialized()
    {
        ObjectToMutate();
    }
    private void EditKlant()
    {
        UserRequest.Edit resquest = new()
        {
            KlantId = klant.Id,
            Klant = model
        };
        UserService.EditAsync(resquest);
        StateHasChanged();
    }

    public void ObjectToMutate()
    {
        model.FirstName = klant.FirstName;
        model.Name= klant.Name;
        model.Email= klant.Email;
        model.PhoneNumber= klant.PhoneNumber;
        if(klant.Opleiding is not null)
        {
            model.Opleiding = klant.Opleiding;
        }
        else
        {
            model.Bedrijf = klant.Bedrijf;
        }
        
    }
}
