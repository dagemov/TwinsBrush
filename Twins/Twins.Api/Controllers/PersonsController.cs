using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonsController(DataContext context)
        {
            _context = context;
        } 
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Persons
                .Include(p=>p.Weeks)
                .ToListAsync());
        }
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
           var Person = _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (Person == null)
            {
                return NotFound();
            }
            return Ok(Person);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Person person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Persons.Add(person);
                    await _context.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }
            return Ok(person);

        }
    }
}
