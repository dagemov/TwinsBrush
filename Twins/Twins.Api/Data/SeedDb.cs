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
            await CheckCategoriesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category()
                {
                    Name = "Normal Paint",
                });
                _context.Categories.Add(new Category()
                {
                    Name = "Powe Wash",
                });
                _context.Categories.Add(new Category()
                {
                    Name = "Deep Clean",                    
                });
                await _context.SaveChangesAsync();
            }
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
                    Name = "United States",
                    States = new List<State>
                    {
                        new State{
                            Name="Connecticut",
                            Cities = new List<City> 
                            { 
                                new City 
                                {
                                    Name="Bridgeport",
                                    Streets = new List<Street>
                                    {
                                        new Street
                                        {
                                            Name="Chospey Hill",
                                            ZipCode="06606",
                                            StreetNumer="1282"
                                        },
                                        new Street
                                        {
                                            Name="Main St",
                                            ZipCode="06809",
                                            StreetNumer="385"
                                        },
                                        new Street
                                        {
                                            Name="Connecticut Av",
                                            ZipCode="07539",
                                            StreetNumer="754"
                                        }
                                    }
                                },
                                new City
                                {
                                    Name="Norwalk",
                                },
                                new City
                                {
                                    Name="Trumbull",
                                },
                                new City
                                {
                                    Name="Wesport",
                                }
                            }
                        },
                        new State{Name="New York"},
                        new State{Name="Pensilvania"}
                    }
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
