using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/serviceDays")]
    public class ServiceDaysController : ControllerBase
    {
        private readonly DataContext _context;

        public ServiceDaysController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
           var queryable= _context.ServiceDays
                .AsQueryable();
            if (queryable == null)
            {
                return BadRequest();
            }
            return Ok(await queryable
                .ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var ServiceDay = await _context.ServiceDays.FirstOrDefaultAsync(x => x.Id == id);
            if (ServiceDay == null)
            {
                return NotFound();
            }          
            return Ok(ServiceDay);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ServiceDay = await _context.ServiceDays.FirstOrDefaultAsync(x => x.Id == id);
            if (ServiceDay == null)
            {
                return NotFound();
            }

            _context.ServiceDays.Remove(ServiceDay);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

   
}
