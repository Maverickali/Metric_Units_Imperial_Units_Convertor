using Imperial_Metric.Application.Interfaces;
using Imperial_Metric.Domain.Common;
using Imperial_Metric.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace Imperial_Metric.Infrastructure.Context
{
    public class ApplicationDbContext :  IdentityUserContext<IdentityUser>
    {
        private readonly IDateTimeService _dateTime;
        private readonly ILoggerFactory _loggerFactory;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDateTimeService dateTime,
            ILoggerFactory loggerFactory
            ) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _loggerFactory = loggerFactory;
        }

        public DbSet<Conversions> Conversions { get; set; }
        public DbSet<ConversionsRates> ConversionsRates { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
         
            builder.Entity<Conversions>().HasData(new List<Conversions>() {
            
                new Conversions { Id = 1, conversionName="Length" },
                new Conversions { Id = 2, conversionName="Mass" },
                new Conversions { Id = 3, conversionName="Speed" },
                new Conversions { Id = 4, conversionName="Temperature" },
                new Conversions { Id = 5, conversionName="Pressure" },
                new Conversions { Id = 6, conversionName="Volume" }
            });
            builder.Entity<ConversionsRates>().HasData(new List<ConversionsRates>()
            {
                new ConversionsRates { Id = newGuid() , Name = "Celsius to Fahrenheit", FromUnit = "Celsius", ToUnit = "Fahrenheit", ConversionFactor = 1.8, ConversionOffset = 32, ConversionId=4},
                new ConversionsRates { Id = newGuid(), Name = "Fahrenheit to Celsius", FromUnit = "Fahrenheit", ToUnit = "Celsius", ConversionFactor = 0.5555555556, ConversionOffset = -32, ConversionId=4},
                 //Length
                new ConversionsRates { Id = newGuid(), Name = "Meters to Feet", FromUnit = "Meters", ToUnit = "Feet", ConversionFactor = 3.280839895, ConversionId=1},
                new ConversionsRates { Id = newGuid(), Name = "Meters to Yard", FromUnit = "Meters", ToUnit = "Yard", ConversionFactor = 1.09361, ConversionId=1},
                new ConversionsRates { Id = newGuid(), Name = "Feet to Meters", FromUnit = "Feet", ToUnit = "Meters", ConversionFactor = 0.3048, ConversionId=1},

                //Mass
                new ConversionsRates { Id = newGuid(),  Name = "Kilograms to Pounds", FromUnit = "Kilograms", ToUnit = "Pounds", ConversionFactor = 2.20462, ConversionId = 2},
                new ConversionsRates { Id = newGuid(),  Name = "Pounds to Kilograms", FromUnit = "Pounds", ToUnit = "Kilograms", ConversionFactor = 0.453592, ConversionId = 2},

                //Volume
                new ConversionsRates { Id = newGuid(), Name = "Liters to Gallons", FromUnit = "Liters", ToUnit = "Gallons", ConversionFactor = 0.264172, ConversionId=6 },
                new ConversionsRates { Id = newGuid(), Name = "Gallons to Liters", FromUnit = "Gallons", ToUnit = "Liters", ConversionFactor = 3.78541, ConversionId=6 },

                //Pressure
                new ConversionsRates { Id = newGuid(), Name = "Pascals to PSI", FromUnit = "Pascals", ToUnit = "PSI", ConversionFactor = 0.000145038, ConversionId=5 },
                new ConversionsRates { Id = newGuid(), Name = "PSI to Pascals", FromUnit = "PSI", ToUnit = "Pascals", ConversionFactor = 6894.76, ConversionId=5 },

                //Speed
                new ConversionsRates { Id = newGuid(), Name = "Kilometers to Miles", FromUnit = "Kilometers per hour", ToUnit = "Miles per hour", ConversionFactor = 0.621371, ConversionId=3 },
                new ConversionsRates { Id = newGuid(), Name = "Miles to Kilometers", FromUnit = "Miles per hour", ToUnit = "Kilometers per hour", ConversionFactor = 1.60934 , ConversionId = 3}

                
                });

            base.OnModelCreating(builder);
        }


        private static string newGuid()
        {
            return Guid.NewGuid().ToString("D");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
