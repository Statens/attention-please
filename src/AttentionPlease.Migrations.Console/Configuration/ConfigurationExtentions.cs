namespace AttentionPlease.Migrations.Console.Configuration
{
    using System;
    using AttentionPlease.EFCore;
    using AttentionPlease.Domain.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.EntityFrameworkCore;

    public static class ConfigurationExtentions
    {
        public static IConfiguration BuildConfiguration(string basePath, string[] args)
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables(prefix: "ATTENTION_PLEASE")
                .AddCommandLine(args);

            if (isDevelopment)
            {
                builder = builder.AddUserSecrets<Program>();
            }

            return builder.Build();
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Add logging
            // LoggingBuilder loggingBuilder;
            /*
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                // .AddSerilog()
                .AddDebug());
                */
            serviceCollection.AddLogging();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            var connectionString = configuration.GetValue<string>("AttentionPleaseDb:ConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<AttentionPleaseDBContext>().UseSqlServer(connectionString);
            
            var dbcontext = new AttentionPleaseDBContext(optionsBuilder.Options);
            
            serviceCollection.AddSingleton<AttentionPleaseDBContext>(dbcontext);
            
            return serviceCollection;
        }
    }
}