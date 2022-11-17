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
using Shared.Authentication;
using Shared.FysiekeServers;
using Services.FysiekeServer;
using Shared.VMContracts;
using Services.VMContracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//MOCKDATA
    builder.Services.AddSingleton<IVirtualMachineService, FakeVirtualMachineService>();
    builder.Services.AddSingleton<IUserService, FakeUserService>();
    builder.Services.AddSingleton<IProjectService, FakeProjectService>();
    //builder.Services.AddSingleton<IAuthenticationService, >
    builder.Services.AddSingleton<IFysiekeServerService, FakeServerService>();
    builder.Services.AddSingleton<IVMContractService, FakeVMContractService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSidepanel();

/*builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});*/

await builder.Build().RunAsync();
