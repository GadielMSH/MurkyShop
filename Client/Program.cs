using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MurkyShop.Client;
using MurkyShop.Client.Services;
using MurkyShop.Client.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7123/") });

builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
