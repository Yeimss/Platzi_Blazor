using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Platzi_Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiUrl = builder.Configuration.GetValue<string>("apiUrl")!;
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


await builder.Build().RunAsync();
