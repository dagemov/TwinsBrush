using Twins.Shared.Entities;

namespace Twins.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();//Update database
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia"
                });
                _context.Countries.Add(new Country
                {
                    Name = "United States"
                });
                _context.Countries.Add(new Country
                {
                    Name = "Venezuela"
                });
                _context.Countries.Add(new Country
                {
                    Name = "Puerto Rico"
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
