﻿// <auto-generated />
using System;
using BeanSceneApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeanSceneApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BeanSceneApp.Models.Area", b =>
                {
                    b.Property<string>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AreaId");

                    b.ToTable("Area");

                    b.HasData(
                        new
                        {
                            AreaId = "M",
                            Name = "Main"
                        },
                        new
                        {
                            AreaId = "O",
                            Name = "Outside"
                        },
                        new
                        {
                            AreaId = "B",
                            Name = "Balcony"
                        });
                });

            modelBuilder.Entity("BeanSceneApp.Models.Availability", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("Time");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<int>("MaxTables")
                        .HasColumnType("int");

                    b.Property<string>("SittingType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TablesAvailable")
                        .HasColumnType("int");

                    b.HasKey("Date", "StartTime");

                    b.HasIndex("SittingType");

                    b.HasIndex("StartTime");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("BeanSceneApp.Models.AvailableTable", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("Time");

                    b.Property<string>("AreaId")
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("TableNum")
                        .HasColumnType("int");

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.HasKey("Date", "StartTime", "AreaId", "TableNum");

                    b.HasIndex("BookingId");

                    b.HasIndex("AreaId", "TableNum");

                    b.ToTable("AvailableTable");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrivateBooking")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("NumOfGuests")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequiredTables")
                        .HasColumnType("int");

                    b.Property<int>("Source")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("Time");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Date", "StartTime");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BeanSceneApp.Models.SittingType", b =>
                {
                    b.Property<string>("SittingName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SittingName");

                    b.ToTable("SittingType");

                    b.HasData(
                        new
                        {
                            SittingName = "Breakfast"
                        },
                        new
                        {
                            SittingName = "Lunch"
                        },
                        new
                        {
                            SittingName = "Dinner"
                        },
                        new
                        {
                            SittingName = "Private Event"
                        });
                });

            modelBuilder.Entity("BeanSceneApp.Models.Table", b =>
                {
                    b.Property<string>("AreaId")
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("TableNum")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TableName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasComputedColumnSql("[AreaId] + CONVERT(NVARCHAR, [TableNum])");

                    b.HasKey("AreaId", "TableNum");

                    b.ToTable("Table");

                    b.HasData(
                        new
                        {
                            AreaId = "M",
                            TableNum = 1
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 2
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 3
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 4
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 5
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 6
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 7
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 8
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 9
                        },
                        new
                        {
                            AreaId = "M",
                            TableNum = 10
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 1
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 2
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 3
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 4
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 5
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 6
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 7
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 8
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 9
                        },
                        new
                        {
                            AreaId = "B",
                            TableNum = 10
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 1
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 2
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 3
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 4
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 5
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 6
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 7
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 8
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 9
                        },
                        new
                        {
                            AreaId = "O",
                            TableNum = 10
                        });
                });

            modelBuilder.Entity("BeanSceneApp.Models.Timeslot", b =>
                {
                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("StartTime");

                    b.ToTable("Timeslot");

                    b.HasData(
                        new
                        {
                            StartTime = new TimeSpan(0, 8, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 11, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 12, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 14, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 15, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 16, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 17, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 18, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 19, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            StartTime = new TimeSpan(0, 21, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BeanSceneApp.Models.Availability", b =>
                {
                    b.HasOne("BeanSceneApp.Models.SittingType", null)
                        .WithMany()
                        .HasForeignKey("SittingType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeanSceneApp.Models.Timeslot", null)
                        .WithMany()
                        .HasForeignKey("StartTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeanSceneApp.Models.AvailableTable", b =>
                {
                    b.HasOne("BeanSceneApp.Models.Booking", null)
                        .WithMany("AvailableTables")
                        .HasForeignKey("BookingId");

                    b.HasOne("BeanSceneApp.Models.Table", null)
                        .WithMany()
                        .HasForeignKey("AreaId", "TableNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeanSceneApp.Models.Availability", null)
                        .WithMany()
                        .HasForeignKey("Date", "StartTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeanSceneApp.Models.Booking", b =>
                {
                    b.HasOne("BeanSceneApp.Models.Availability", null)
                        .WithMany()
                        .HasForeignKey("Date", "StartTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeanSceneApp.Models.Table", b =>
                {
                    b.HasOne("BeanSceneApp.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BeanSceneApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BeanSceneApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeanSceneApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BeanSceneApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeanSceneApp.Models.Booking", b =>
                {
                    b.Navigation("AvailableTables");
                });
#pragma warning restore 612, 618
        }
    }
}
