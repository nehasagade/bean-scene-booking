using BeanSceneApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace BeanSceneApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Area> Area { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<SittingType> SittingType { get; set; }
        public DbSet<Timeslot> Timeslot { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<AvailableTable> AvailableTable { get; set; }
        internal static Task<string?> ToListAsync()
        {
            throw new NotImplementedException();
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Timeslot>().HasData(
                new Timeslot
                {
                    StartTime = new TimeSpan(8, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(9, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(10, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(11, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(12, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(13, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(14, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(15, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(16, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(17, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(18, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(19, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(20, 0, 0)
                },
                new Timeslot
                {
                    StartTime = new TimeSpan(21, 0, 0)
                });
            builder.Entity<Area>().HasData(
                new Area
                {
                    AreaId = 'M',
                    Name = "Main"
                },
                new Area
                {
                    AreaId = 'O',
                    Name = "Outside"
                },
                new Area
                {
                    AreaId = 'B',
                    Name = "Balcony"
                }
            );

            builder.Entity<Table>().HasKey(t => new { t.AreaId,t.TableNum });
            builder.Entity<Table>()
                .Property(t => t.TableName)
                .HasComputedColumnSql("[AreaId] + CONVERT(NVARCHAR, [TableNum])");
            builder.Entity<Table>()
                .HasData(new Table
                {
                    AreaId = 'M',
                    TableNum = 1,
                                     
                    
                },
                new Table
                {
                    AreaId = 'M',
                    TableNum = 2,                
                    

                },
                new Table
                {
                    AreaId = 'M',
                    TableNum = 3,
                    
                    
                },
                new Table
                {
                    AreaId = 'M',
                    TableNum = 4,
                    
                    

                },
                new Table
                {
                    AreaId = 'M',
                    TableNum = 5,
                    
                    

                },
                new Table
                {
                    AreaId = 'M',
                    TableNum = 6,
                    
                    

                },
                new Table
                {
                    AreaId = 'M',
                    TableNum = 7,
                    
                    
                },
                new Table
                {
                    AreaId = 'M',
                    TableNum = 8,
                    
                    
                },
                new Table
                {
                    AreaId = 'M',
                    TableNum = 9,
                    
                    
                },
                new Table
                {
                     AreaId = 'M',
                     TableNum = 10,
                     
                     
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 1,
                    

                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 2,
                    
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 3,
                    
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 4,
                    
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 5,
                    
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 6,
                    
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 7,
                    
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 8,
                    
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 9,
                    
                },
                new Table
                {
                    AreaId = 'B',
                    TableNum = 10,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 1,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 2,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 3,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 4,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 5,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 6,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 7,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 8,
                   
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 9,
                    
                },
                new Table
                {
                    AreaId = 'O',
                    TableNum = 10,
                  
                }
            );
            builder.Entity<SittingType>()
                .HasData(new SittingType
                {
                    SittingName = "Breakfast"
                },
                new SittingType
                {
                    SittingName = "Lunch"
                },
                new SittingType
                {
                    SittingName = "Dinner"
                },
                new SittingType
                {
                    SittingName = "Private Event"
                });
            builder.Entity<Availability>()
                .HasOne<SittingType>()
                .WithMany()
                .HasForeignKey(a => a.SittingType);
            builder.Entity<Availability>()
                .HasOne<Timeslot>()
                .WithMany()
                .HasForeignKey(a => a.StartTime);
            builder.Entity<Availability>()
                .HasKey(a => new { a.Date, a.StartTime });
            builder.Entity<Booking>()
                .HasOne<Availability>()
                .WithMany()
                .HasForeignKey(b => new { b.Date, b.StartTime });
            builder.Entity<Booking>()
                .Property(b => b.IsPrivateBooking)
                .HasDefaultValue(false);
            builder.Entity<AvailableTable>().HasKey(t => new { t.Date, t.StartTime,t.AreaId, t.TableNum });
            builder.Entity<AvailableTable>()
                .HasOne<Availability>()
                .WithMany()
                .HasForeignKey(t => new { t.Date, t.StartTime });
            builder.Entity<AvailableTable>()
                .HasOne<Table>()
                .WithMany()
                .HasForeignKey(t => new { t.AreaId, t.TableNum });
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
        public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                builder.Property(u => u.FirstName).HasMaxLength(255);
                builder.Property(u => u.LastName).HasMaxLength(255);
            }
        }
    }
}