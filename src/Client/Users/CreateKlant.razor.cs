using Domain.VirtualMachines.VirtualMachine;
using Microsoft.AspNetCore.Components;
using Shared.Users;
using Shared.VirtualMachines;
using Domain.Users;

namespace Client.Users
{
    public partial class CreateKlant
    {
        //public UserDto.Create model = new();
        [Inject] public IUserService userService { get; set; }
        [Inject] NavigationManager NavMan { get; set; }

        protected override async Task OnInitializedAsync()
        {
          //  model.Contactpersoon = new Domain.Common.ContactDetails();
        }

        private async void RegistreerKlant()
        {
           /* UserRequest.Create request = new()
            {
                User = model
            };
            await userService.CreateAsync(request);
           */

            //TODO: User inloggen
            NavMan.NavigateTo($"/virtualmachines");
        }
    }
}
