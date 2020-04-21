using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AttentionPlease.Spa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseWebRoot("svelte/public")
                .UseUrls("http://localhost:6000", "https://localhost:6001")
                .UseStartup<Startup>();
    }
}
