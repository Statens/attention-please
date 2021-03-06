﻿// <auto-generated />
using System;
using AttentionPlease.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AttentionPlease.EFCore.Migrations
{
    [DbContext(typeof(AttentionPleaseDBContext))]
    [Migration("20200101205957_InitialCreate3")]
    partial class InitialCreate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AttentionPlease.Domain.Models.AnniversaryCelebration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("CalendarId");

                    b.Property<DateTime>("Day");

                    b.Property<string>("Description");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("AnniversaryCelebrations");
                });

            modelBuilder.Entity("AttentionPlease.Domain.Models.Calendar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Calendars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("169c2d8d-4db8-45f6-9278-30890a3e8bc3"),
                            Name = "Fam Jerndin"
                        });
                });

            modelBuilder.Entity("AttentionPlease.Domain.Models.CalendarSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("CalendarId");

                    b.Property<Guid?>("CalendarId1");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("CalendarId1");

                    b.ToTable("CalendarSubscriptions");
                });

            modelBuilder.Entity("AttentionPlease.Domain.Models.AnniversaryCelebration", b =>
                {
                    b.HasOne("AttentionPlease.Domain.Models.Calendar")
                        .WithMany("AnniversaryCelebrations")
                        .HasForeignKey("CalendarId");
                });

            modelBuilder.Entity("AttentionPlease.Domain.Models.CalendarSubscription", b =>
                {
                    b.HasOne("AttentionPlease.Domain.Models.Calendar", "Calendar")
                        .WithMany()
                        .HasForeignKey("CalendarId");

                    b.HasOne("AttentionPlease.Domain.Models.Calendar")
                        .WithMany()
                        .HasForeignKey("CalendarId1");
                });
#pragma warning restore 612, 618
        }
    }
}
