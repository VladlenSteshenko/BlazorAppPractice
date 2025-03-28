using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static BlazorApp1.Components.Pages.CountryDetails;
using static BlazorApp1.Components.Pages.Weather;

namespace BlazorApp1
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CountryDetail> CountryDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set Guid as primary key for CountryDetail.
            modelBuilder.Entity<CountryDetail>()
                .HasKey(c => c.Id);

            // Configure conversions for collection and dictionary properties using JSON.
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            modelBuilder.Entity<CountryDetail>()
                .Property(c => c.Capital)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, jsonOptions),
                    v => JsonSerializer.Deserialize<List<string>>(v, jsonOptions));

            modelBuilder.Entity<CountryDetail>()
                .Property(c => c.Currencies)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, jsonOptions),
                    v => JsonSerializer.Deserialize<Dictionary<string, CurrencyInfo>>(v, jsonOptions));

            modelBuilder.Entity<CountryDetail>()
                .Property(c => c.Languages)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, jsonOptions),
                    v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, jsonOptions));

            modelBuilder.Entity<CountryDetail>()
                .Property(c => c.Timezones)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, jsonOptions),
                    v => JsonSerializer.Deserialize<List<string>>(v, jsonOptions));

            modelBuilder.Entity<CountryDetail>().OwnsOne(c => c.Name);
            modelBuilder.Entity<CountryDetail>().OwnsOne(c => c.Flags);
            modelBuilder.Entity<CountryDetail>().OwnsOne(c => c.Maps);

            base.OnModelCreating(modelBuilder);
        }
    }
}
