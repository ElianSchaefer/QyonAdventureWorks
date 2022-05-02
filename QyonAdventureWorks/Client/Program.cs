global using QyonAdventureWorks.Client.Services.CompetidoresService;
global using QyonAdventureWorks.Client.Services.HistoricoService;
global using QyonAdventureWorks.Client.Services.PistaService;
global using QyonAdventureWorks.Shared.Model;
global using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QyonAdventureWorks.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICompetidoresService, CompetidoresService>();
builder.Services.AddScoped<IHistoricoService, HistoricoService>();
builder.Services.AddScoped<IPistaService, PistaService>();

await builder.Build().RunAsync();
