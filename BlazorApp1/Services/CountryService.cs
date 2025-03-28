using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BlazorApp1
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;

        public CountryService(HttpClient httpClient, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        // Seed the database with country details if empty.
        public async Task SeedCountriesAsync()
        {
            if (!await _context.CountryDetails.AnyAsync())
            {
                var json = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all?fields=name,cca2,capital,region,subregion,area,population,currencies,languages,timezones,independent,flags,maps");
                var countries = JsonSerializer.Deserialize<CountryDetail[]>(json);
                if (countries != null)
                {
                    _context.CountryDetails.AddRange(countries);
                    await _context.SaveChangesAsync();
                }
            }
        }

        // Get a simplified list of countries from the CountryDetails.
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.CountryDetails
                .AsNoTracking()
                .Select(c => new Country
                {
                    Id = c.Id,
                    Name = c.Name,
                    Capital = c.Capital,
                    Currencies = c.Currencies,
                    Languages = c.Languages,
                    Area = c.Area
                })
                .ToListAsync();
        }

        // Get the detailed country info by name.
        public async Task<CountryDetail?> GetCountryDetailAsync(string name)
        {
            return await _context.CountryDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name.Common.ToLower() == name.ToLower());
        }
    }
}
