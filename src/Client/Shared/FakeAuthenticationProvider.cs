using Domain.Users;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Client.Shared
{
    public class FakeAuthenticationProvider : AuthenticationStateProvider
    {
        public static ClaimsPrincipal Anonymous => new(new ClaimsIdentity(new[] { 
            new Claim(ClaimTypes.Name, "Guest"),
        }));
        public static ClaimsPrincipal AdminConsultant => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Consultant Admin"),
            new Claim(ClaimTypes.Email, "fake-consultant@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin-Consultant"),
        }, "Fake Authentication"));

        public static ClaimsPrincipal AdminBeheer => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Beheer Admin"),
            new Claim(ClaimTypes.Email, "fake-beheer@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin-Beheer"),
        }, "Fake Authentication"));

        public static ClaimsPrincipal Customer => new(new ClaimsIdentity(new[]
{
            new Claim(ClaimTypes.Name, "Fake Customer"),
            new Claim(ClaimTypes.Email, "fake-customer@gmail.com"),
            new Claim(ClaimTypes.Role, "Customer"),
        }, "Fake Authentication"));


        public ClaimsPrincipal Current { get; set; } = Anonymous;


        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(Current));
        }

        public void ChangeAuthenticationState(ClaimsPrincipal claims)
        {
            Current = claims;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
