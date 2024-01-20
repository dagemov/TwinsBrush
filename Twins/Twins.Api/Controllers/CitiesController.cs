using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public CitiesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> CityGetAsync()
        {
            return Ok(await _context.Cities
                .Include(s => s.Streets)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> CityGetAsync(int id)
        {
            var city = await _context.Cities
                .Include (s => s.Streets)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
        [HttpPost]
        public async Task<IActionResult> CityPostAsync(City city)
        {
            if (ModelState.IsValid)
            {
                _context.Cities.Add(city);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an City with the same Name : < {city.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(city);
        }
        [HttpPut]
        public async Task<IActionResult> CityPutAsync(City city)
        {
            if (ModelState.IsValid)
            {
                _context.Cities.Update(city);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an City with the same Name : < {city.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(city);
        }
        //Always { } in the rute sebastian!!!
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> CityDeleteAsync(int id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
