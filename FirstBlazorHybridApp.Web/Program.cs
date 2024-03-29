using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace FirstBlazorHybridApp.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<FirstBlazorHybridApp.WebUI.App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44346") });
            builder.Services.AddSingleton<CounterState>();
            //builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(builder.HostEnvironment., @"wwwroot")));
            await builder.Build().RunAsync();
        }
    }
}