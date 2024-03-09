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
        
    }

   
}
