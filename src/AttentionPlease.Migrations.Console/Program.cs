using System.IO;
using AttentionPlease.Domain.Models;
using AttentionPlease.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AttentionPlease.Migrations.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example: dotnet run "AttentionPlease:DbProvider=SqlServer" "ConnectionStrings:Storage=TheProdSettings"

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();

            var connectionString = configuration.GetConnectionString("AttentionPleaseDb");

            System.Console.WriteLine(connectionString);
            System.Console.WriteLine(configuration.GetValue<string>("AttentionPleaseDb:DbProvider"));


            System.Console.WriteLine("Hello World!");

            var optionsBuilder = new DbContextOptionsBuilder<AttentionPleaseDBContext>().UseSqlServer(connectionString);

            var context = new AttentionPleaseDBContext(optionsBuilder.Options);

            context.CalendarSubscribers.Add(new CalendarSubscriber());
            context.SaveChanges();
            // context.Database.Migrate();
        }
    }
}
