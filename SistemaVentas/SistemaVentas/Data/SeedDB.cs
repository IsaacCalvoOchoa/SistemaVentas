using SistemaVentas.Data.Entities;
using SistemaVentas.Enums;
using SistemaVentas.Helpers;

namespace SistemaVentas.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Isaac", "Calvo", "Isaaccalvoochoa@yopmail.com", "686 188 1069", "Calle Deveza 1241", UserType.Admin);
            await CheckUserAsync("2020", "Ale", "Calvo", "Calvoochoa77@gmail.com", "686 188 1069", "Calle Deveza 1241", UserType.User);
        }

        private async Task<User> CheckUserAsync(
    string document,
    string firstName,
    string lastName,
    string email,
    string phone,
    string address,
    UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.countries.Any())
            {
                _context.countries.Add(new Country
                {
                    Name = "Mexico",
                    States = new List<State>()
                    {
                        new State()  
                        {
                            Name = "Baja California",
                            Cities = new List<City>()
                            {
                                new City { Name = "Mexicali"},
                                new City { Name = "Tijuana"},
                                new City { Name = "Ensenada"},
                                new City { Name = "Tecate"},
                            }
                        },
                        new State()
                        {
                            Name = "Sonora",
                            Cities = new List<City>()
                            {
                                new City { Name = "Penasco"},
                                new City { Name = "Sonoyta"},
                                new City { Name = "Hermosillo"},
                            }
                        },
                    }

                });

                _context.countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>()
                            {
                                new City { Name = "Miami"},
                                new City { Name = "Orlando"},
                            }
                        },
                        new State()
                        {
                            Name = "California",
                            Cities = new List<City>()
                            {
                                new City { Name = "San Diego"},
                                new City { Name = "Los Angeles"},
                            }
                        },
                    }

                });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.categories.Any())
            {
                _context.categories.Add(new Category { Name = "Tecnología" });
                _context.categories.Add(new Category { Name = "Ropa" });
                _context.categories.Add(new Category { Name = "Calzado" });
                _context.categories.Add(new Category { Name = "Belleza" });
                _context.categories.Add(new Category { Name = "Nutricion" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
