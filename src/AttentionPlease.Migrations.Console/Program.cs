using System;
using AttentionPlease.EFCore;
using Microsoft.EntityFrameworkCore;

namespace AttentionPlease.Migrations.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            var optionsBuilder = new DbContextOptionsBuilder<AttentionPleaseDBContext>().UseSqlServer(AttentionPleaseDBContext.DbConnectionString);

            var options = new DbContextOptions<AttentionPleaseDBContext>();
            var context = new AttentionPleaseDBContext(optionsBuilder.Options);

            context.Database.Migrate();
        }
    }
}
