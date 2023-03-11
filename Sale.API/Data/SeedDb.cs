using Sale.Shared.Entities;

namespace Sale.API.Data
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
            await _context.Database.EnsureCreatedAsync();

            await checkCountriesAsync();
        }

        private async Task checkCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>
                    {
                        new State
                        {
                            Name = "Antioquia",
                            Cities= new List<City>
                            {
                                new City{ Name = "medellin" },
                                new City{ Name = "Bello" },
                                new City{ Name = "Copacabana" },
                                 new City{ Name = "Envigado" },
                                  new City{ Name = "Rionegro" },
                                   new City{ Name = "Itagui" }
                            }
                        },
                        new State
                        {
                            Name = "Bogota",
                            Cities= new List<City>
                            {
                                new City{ Name = "Unsaque" },
                                new City{ Name = "Champinero" },
                                new City{ Name = "Santa fe" },
                                new City{ Name = "Useme" },
                                new City{ Name = "Bosa" }
                            }
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>
                    {
                        new State
                        {
                            Name = "Florida",
                            Cities= new List<City>
                            {
                                new City{ Name = "Orlando" },
                                new City{ Name = "Miami" },
                                new City{ Name = "Tampa" },
                                 new City{ Name = "Fort lauderdale" },
                                  new City{ Name = "Key West" }
                            }
                        },
                        new State
                        {
                            Name = "Texas",
                            Cities= new List<City>
                            {
                                new City{ Name = "Houston" },
                                new City{ Name = "San Antonio" },
                                new City{ Name = "Dallas" },
                                new City{ Name = "Austin" },
                                new City{ Name = "El paso" }
                            }
                        }
                    }
                });
                _context.Countries.Add(new Country { Name = "Mexico" });
                _context.Countries.Add(new Country { Name = "Perú" });

                await _context.SaveChangesAsync();
            }
        }
    }
}
