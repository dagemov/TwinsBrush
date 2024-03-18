using Microsoft.EntityFrameworkCore;
using Twins.Api.Helpers;
using Twins.Api.Helpers.Interfaces;
using Twins.Api.Services;
using Twins.Shared.Entities;
using Twins.Shared.Responses;

namespace Twins.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IApiService apiService,IUserHelper userHelper)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();//Update database

            await CheckCountriesAsync();
            await CheckCategoriesAsync();

            await CheckRolesAsync();
            await CheckUserAsync("1010", "Sebastian", "Martinez", "Dagemov1@yopmail.com", "2039234322", UserType.Admin);
            await CheckUserAsync("2020", "Felipe", "Martinez", "Felcos@yopmail.com", "4758694513", UserType.Employed);
            await CheckUserAsync("5789", "Victor", "Manuel", "Manuel123@yopmail.com", "3206224516", UserType.Employed);
            await CheckUserAsync("5698", "Stefany", "Abelaez", "Pepe@yopmail.com", "9865341274", UserType.Employed);
            await CheckUserAsync("70512938", "Carlos", "Alberto", "Alberto123@yopmail.com", "36096814", UserType.Mannager);
            await CheckUserAsync("61158237", "Isabel", "Calvo", "isabel429@yopmail.com", "3109234658", UserType.Mannager);
            await CheckUserAsync("698745", "Sara", "Squivolqui", "Sara@yopmail.com", "5897641253", UserType.User);

        }

        private async Task<User> CheckUserAsync(string Document, string FirstName, string LastName, string Email, string PhoneNumber, UserType userType)
        {
           var user = await _userHelper.GetUserAsync(Email);
            if (user == null)
            {
                user = new User
                {
                    Documment=Document,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    UserName = Email,
                    UserType = userType,
                    City = _context.Cities.FirstOrDefault(),
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
            await _userHelper.CheckRoleAsync(UserType.Employed.ToString());
            await _userHelper.CheckRoleAsync(UserType.Mannager.ToString());

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
                Response responseCountries = await _apiService.GetListAsync<CountryResponse>("/v1", "/countries");
                if (responseCountries.IsSuccess)
                {
                    List<CountryResponse> countries = (List<CountryResponse>)responseCountries.Result!;
                    foreach (CountryResponse countryResponse in countries)
                    {
                        if (countryResponse.Name == "United States" || countryResponse.Name == "Colombia")
                        {
                            Country country = await _context.Countries!.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                            if (country == null)
                            {

                                country = new() { Name = countryResponse.Name!, States = new List<State>() };
                                Response responseStates = await _apiService.GetListAsync<StateResponse>("/v1", $"/countries/{countryResponse.Iso2}/states");
                                if (responseStates.IsSuccess)
                                {
                                    List<StateResponse> states = (List<StateResponse>)responseStates.Result!;
                                    foreach (StateResponse stateResponse in states!)
                                    {
                                        State state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                        if (state == null)
                                        {
                                            state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                            Response responseCities = await _apiService.GetListAsync<CityResponse>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                            if (responseCities.IsSuccess)
                                            {
                                                List<CityResponse> cities = (List<CityResponse>)responseCities.Result!;
                                                foreach (CityResponse cityResponse in cities)
                                                {
                                                    if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")//utf-8 no reconoce estas como diferentes y revienta el app , en futuro hacerlo si sale con otras
                                                    {
                                                        continue;
                                                    }
                                                    City city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                                    if (city == null)
                                                    {
                                                        state.Cities.Add(new City() { Name = cityResponse.Name! });
                                                    }
                                                }
                                            }
                                            if (state.CitiesNumber > 0)
                                            {
                                                country.States.Add(state);
                                            }
                                        }
                                    }
                                }
                                if (country.StatesNumber > 0)
                                {
                                    if (country.Name == "United States" || country.Name == "Colombia")
                                    {
                                        _context.Countries.Add(country);
                                    }

                                    await _context.SaveChangesAsync();
                                }
                            }
                        }

                    }
                }

            }
        }
    }
}
