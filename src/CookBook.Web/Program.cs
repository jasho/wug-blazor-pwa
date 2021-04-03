using CookBook.BL.Web;
using CookBook.DAL.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CookBook.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            Install(builder);
            await builder.Build().RunAsync();
        }

        private static void Install(WebAssemblyHostBuilder builder)
        {
            new DALWebInstaller().Install(builder.Services);
            new BLWebInstaller().Install(builder.Services);
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        }
    }
}
