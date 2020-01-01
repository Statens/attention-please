using Microsoft.EntityFrameworkCore;
using AttentionPlease.Domain.Models;

namespace AttentionPlease.EFCore
{
    public class AttentionPleaseDBContext : DbContext
    {
        public AttentionPleaseDBContext(DbContextOptions<AttentionPleaseDBContext> options)
            : base(options)
        { }

        public AttentionPleaseDBContext()
            : base()
        {

        }

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<CalendarSubscription> CalendarSubscriptions { get; set; }

        public DbSet<AnniversaryCelebration> AnniversaryCelebrations { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString: "Server=localhost; Database=AttentionPleaseDb; Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalendarSubscription>().HasOne(typeof(Calendar));
            modelBuilder.Entity<Calendar>().HasData(new Calendar("Fam Jerndin"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
