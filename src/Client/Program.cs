using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using Append.Blazor.Sidepanel;
using Shared.VirtualMachines;
using Services.VirtualMachines;
using Shared.Projects;
using Shared.Users;
using Services.Users;
using Services.Projects;
using Shared.Servers;
using Services.Server;
using Shared.VMContracts;
using Services.VMContracts;
using Microsoft.AspNetCore.Components.Authorization;
using Client.Shared;
using System.Security.Claims;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//MOCKDATA
    builder.Services.AddSingleton<IVirtualMachineService, FakeVirtualMachineService>();
    builder.Services.AddSingleton<IUserService, FakeUserService>();
    builder.Services.AddSingleton<IProjectService, FakeProjectService>();
    builder.Services.AddSingleton<IFysiekeServerService, FakeServerService>();
    builder.Services.AddSingleton<IVMContractService, FakeVMContractService>();

//AUTHENTICATION
    builder.Services.AddAuthorizationCore(options =>
    {
        options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin-Consultant", "Admin-Beheer"));
        options.AddPolicy("BeheerOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin-Beheer"));
        options.AddPolicy("LoggedIn", policy => policy.RequireAuthenticatedUser());
        options.AddPolicy("Guest", policy => policy.RequireClaim(ClaimTypes.Name, "Guest"));

    });
// builder.Services.AddSingleton<AuthenticationStateProvider, FakeAuthenticationProvider>();
    builder.Services.AddScoped<FakeAuthenticationProvider>();
     builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<FakeAuthenticationProvider>());



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSidepanel();

/*builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});*/

await builder.Build().RunAsync();
