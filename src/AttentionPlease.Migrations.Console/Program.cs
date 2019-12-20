using System;
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
            // Example: dotnet run "AttentionPleaseDb:Provider=SqlServer" "ConnectionStrings:Storage=TheProdSettings"

            IConfigurationRoot configuration = BuildConfig(args);

            var connectionString1 = configuration.GetConnectionString("AttentionPleaseDb");
            var connectionString2 = configuration.GetValue<string>("AttentionPleaseDb:ConnectionString");

            System.Console.WriteLine(connectionString1);
            System.Console.WriteLine(connectionString2);
            //System.Console.WriteLine(configuration.GetValue<string>("AttentionPleaseDb:ConnectionString"));
            System.Console.WriteLine(configuration.GetValue<string>("AttentionPleaseDb:Provider"));

            System.Console.WriteLine(configuration.GetValue<string>("AttentionPlease:Db:DbProvider"));

            System.Console.WriteLine("Hello World!");

            var optionsBuilder = new DbContextOptionsBuilder<AttentionPleaseDBContext>().UseSqlServer(connectionString1);

            var context = new AttentionPleaseDBContext(optionsBuilder.Options);
            System.Console.WriteLine("Run Database.Migrate()");
            context.Database.Migrate();

            foreach (var contextCalendar in context.Calendars)
            {
                System.Console.WriteLine(contextCalendar.Name);
            }

            // context.CalendarSubscribers.Add(new CalendarSubscription());
            context.SaveChanges();
        }

        static IConfigurationRoot BuildConfig(string[] args)
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables(prefix: "ATTENTION_PLEASE")
                .AddCommandLine(args);

            if (isDevelopment)
            {
                builder = builder.AddUserSecrets<Program>();
            }

            return builder.Build();
        }
    }
}
