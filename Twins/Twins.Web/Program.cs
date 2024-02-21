using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Twins.Web;
using Twins.Web.Auth;
using Twins.Web.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredModal();
builder.Services.AddSweetAlert2();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderTest>();


builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7170/") });// api url  => https://localhost:7170/
builder.Services.AddScoped<IRepository,Repository>();


await builder.Build().RunAsync();
