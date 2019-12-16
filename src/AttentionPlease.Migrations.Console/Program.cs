using System;
using System.IO;
using AttentionPlease.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace AttentionPlease.Migrations.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example: dotnet run "AttentionPlease:DbProvider=SqlServer" "ConnectionStrings:Storage=TheProdSettings"
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddCommandLine(args);

            IConfigurationRoot configuration = builder.Build();

            System.Console.WriteLine(configuration.GetConnectionString("AttentionPleaseDb"));
            System.Console.WriteLine(configuration.GetValue<string>("AttentionPleaseDb:DbProvider"));


            System.Console.WriteLine("Hello World!");

            // var optionsBuilder = new DbContextOptionsBuilder<AttentionPleaseDBContext>().UseSqlServer(AttentionPleaseDBContext.DbConnectionString);

            // var context = new AttentionPleaseDBContext(optionsBuilder.Options);

            // context.Database.Migrate();
        }
    }
}
