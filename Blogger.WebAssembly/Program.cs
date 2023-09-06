using Blogger.SharedUI.ServiceInterfaces;
using Blogger.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blogger.WebAssembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7231/") });
builder.Services.AddSingleton<IAppService, AppService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();

await builder.Build().RunAsync();
