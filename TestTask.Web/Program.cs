using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestTask.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TestTask.Web;

namespace TestTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            //Add Automapper configurations
            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddMaps(currentAssembly);
            //});
            //builder.Services.AddSingleton(configuration.CreateMapper());
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<ITestTaskApi, TestTaskApi>();
            await builder.Build().RunAsync();
        }
    }
}
