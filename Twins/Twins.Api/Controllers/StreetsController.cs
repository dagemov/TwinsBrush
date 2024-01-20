using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/streets")]
    public class StreetsController : ControllerBase
    {
        private readonly DataContext _context;

        public StreetsController(DataContext context)
        {
           _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> StreetGetAsync()
        {
            return Ok(await _context.Streets
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> StreetGetAsync(int id)
        {
            var street = await _context.Streets.FirstOrDefaultAsync(s => s.Id == id);
            if (street == null)
            {
                return NotFound();
            }
            return Ok(street);
        }
        [HttpPost]
        public async Task<IActionResult> StreetPostAsync(Street street)
        {
            if (ModelState.IsValid)
            {
                _context.Streets.Add(street);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an Street with the same Name : < {street.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(street);
        }
        [HttpPut]
        public async Task<IActionResult> StreetPutAsync(Street street)
        {
            if (ModelState.IsValid)
            {
                _context.Streets.Update(street);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an Street with the same Name : < {street.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(street);
        }
        //Always { } in the rute sebastian!!!
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> StreetDeleteAsync(int id)
        {
            var street = await _context.Streets.FirstOrDefaultAsync(x => x.Id == id);
            if (street == null)
            {
                return NotFound();
            }
            _context.Streets.Remove(street);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
