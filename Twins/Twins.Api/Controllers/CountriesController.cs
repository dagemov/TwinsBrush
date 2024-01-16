using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CountryGetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CountryPostAsync(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                try
                {
                    await _context.SaveChangesAsync();
                }catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(country);
        }
    }
}
