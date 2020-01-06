using System;
using System.IO;
using AttentionPlease.EFCore;
using AttentionPlease.Domain.Models;
using AttentionPlease.Migrations.Console.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AttentionPlease.Migrations.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection().ConfigureServices(BuildConfig(args));
            
            // Create service provider
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            
            using(var context = serviceProvider.GetService<AttentionPleaseDBContext>())
            {
            System.Console.WriteLine("Run Database.Migrate()");
            context.Database.Migrate();

            foreach (var c in context.CalendarSubscriptions)
            {
                context.CalendarSubscriptions.Remove(c);
            }
            foreach (var contextCalendar in context.Calendars)
            {
                context.Calendars.Remove(contextCalendar);
            }
            context.SaveChanges();

            var cal = new Calendar("Fam Jerndin");
            var subscription = new CalendarSubscription
            {
                UserId = "swizkon",
                Calendar = cal
            };
            context.CalendarSubscriptions.Add(subscription);
            
            context.SaveChanges();

            foreach (var contextCalendar in context.Calendars)
            { 
                System.Console.WriteLine(contextCalendar.Name + ": " + contextCalendar.Id);
            }
            }
        }

        static IConfiguration BuildConfig(string[] args)
        {
            return ConfigurationExtentions.BuildConfiguration(Directory.GetCurrentDirectory(), args);
        }
    }
}

// sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyS3curep@ssW0rd" -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2019-GA-ubuntu-16.04
// Example: dotnet run "AttentionPleaseDb:Provider=SqlServer" "ConnectionStrings:Storage=TheProdSettings"

// https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash



/*
# RUn migrations
cd AttentionPlease.EFCore
dotnet ef migrations add InitialCreate -s ../AttentionPlease.Migrations.Console/AttentionPlease.Migrations.Console.csproj

dotnet ef database drop -s ../AttentionPlease.Migrations.Console/AttentionPlease.Migrations.Console.csproj

dotnet ef migrations list -s ../AttentionPlease.Migrations.Console/AttentionPlease.Migrations.Console.csproj
*/