using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using Append.Blazor.Sidepanel;
using Shared.VirtualMachines;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//MOCKDATA
    builder.Services.AddSingleton<IVirtualMachineService, FakeVirtualMachineService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSidepanel();

await builder.Build().RunAsync();
//voor te committen...