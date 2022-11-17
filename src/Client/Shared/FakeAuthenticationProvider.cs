using Domain.Users;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Client.Shared
{
    public class FakeAuthenticationProvider : AuthenticationStateProvider
    {
        public static ClaimsPrincipal Anonymous => new(new ClaimsIdentity());
        public static ClaimsPrincipal AdminConsultant => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Consultant Admin"),
            new Claim(ClaimTypes.Email, "fake-adminCONSULT@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin-"+AdminRole.CONSULTEREN.ToString()),
        }, "Fake Authentication"));

        public static ClaimsPrincipal AdminApproval => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Editor Admin"),
            new Claim(ClaimTypes.Email, "fake-adminEDIT@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin-" + AdminRole.BEHEREN.ToString()),
        }, "Fake Authentication"));

        public static ClaimsPrincipal Cutomer => new(new ClaimsIdentity(new[]
{
            new Claim(ClaimTypes.Name, "Fake Customer"),
            new Claim(ClaimTypes.Email, "fake-customer@gmail.com"),
            new Claim(ClaimTypes.Role, "Customer"),
        }, "Fake Authentication"));




        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(Anonymous));
        }
    }
}
