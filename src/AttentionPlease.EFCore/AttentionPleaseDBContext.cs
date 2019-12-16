using Microsoft.EntityFrameworkCore;
using AttentionPlease.Domain.Models;

namespace AttentionPlease.EFCore
{
    public class AttentionPleaseDBContext : DbContext
    {
        public AttentionPleaseDBContext(DbContextOptions<AttentionPleaseDBContext> options)
            : base(options)
        { }

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<CalendarSubscriber> CalendarSubscribers { get; set; }

        public DbSet<AnniversaryCelebration> AnniversaryCelebrations { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar>().HasData(new Calendar("Fam Jer"));

            //modelBuilder.Entity<Guest>().HasData(new Guest("Alper Ebicoglu", DateTime.Now.AddDays(-10)) { Id = 1 });
            //modelBuilder.Entity<Guest>().HasData(new Guest("George Michael", DateTime.Now.AddDays(-5)) { Id = 2 });
            //modelBuilder.Entity<Guest>().HasData(new Guest("Daft Punk", DateTime.Now.AddDays(-1)) { Id = 3 });

            ////ROOMS
            //modelBuilder.Entity<Room>().HasData(new Room(101, "yellow-room", RoomStatus.Available, false) { Id = 1 });
            //modelBuilder.Entity<Room>().HasData(new Room(102, "blue-room", RoomStatus.Available, false) { Id = 2 });
            //modelBuilder.Entity<Room>().HasData(new Room(103, "white-room", RoomStatus.Unavailable, false) { Id = 3 });
            //modelBuilder.Entity<Room>().HasData(new Room(104, "black-room", RoomStatus.Unavailable, false) { Id = 4 });

            ////RESERVATIONS
            //modelBuilder.Entity<Reservation>().HasData(new Reservation(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(3), 3, 1) { Id = 1 });
            //modelBuilder.Entity<Reservation>().HasData(new Reservation(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(4), 4, 2) { Id = 2 });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
