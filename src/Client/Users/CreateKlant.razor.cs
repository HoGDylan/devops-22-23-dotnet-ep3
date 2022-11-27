using Domain.VirtualMachines.VirtualMachine;
using Microsoft.AspNetCore.Components;
using Shared.Users;
using Shared.VirtualMachines;

namespace Client.Users
{
    public partial class CreateKlant
    {
        public KlantDto.Create model = new();
        [Inject] public IUserService userService { get; set; }
        [Inject] NavigationManager NavMan { get; set; }
        public Boolean isIntern { get; set; } = true;

        private string? emailValue { get; set; }

        public void toggleRelation()
        {
            isIntern = !isIntern;
        }

        private async void RegistreerKlant()
        {
            UserRequest.Create request = new()
            {
                Klant = model
            };
            await userService.CreateAsync(request);

            //TODO: klant inloggen
            NavMan.NavigateTo($"/virtualmachines");
        }
    }
}
