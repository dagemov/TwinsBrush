using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/states")]
    public class StatesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> StateGetAsync()
        {
            return Ok(await _context.Statements
                .Include(s => s.Cities)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> StateGetAsync(int id)
        {
            var state = await _context.Statements
                .Include(s => s.Cities)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }
        [HttpPost]
        public async Task<IActionResult> StatePostAsync(State state)
        {
            if (ModelState.IsValid)
            {              
                try
                {
                    //TODO: CHANG EALL POST AND PUT LIKE THIS SHAPE
                    _context.Statements.Add(state);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an State with the same Name : < {state.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(state);
        }
        [HttpPut]
        public async Task<IActionResult> StatePutAsync(State state)
        {
            if (ModelState.IsValid)
            {
                _context.Statements.Update(state);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an State with the same Name : < {state.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(state);
        }
        //Always { } in the rute sebastian!!!
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> StateDeleteAsync(int id)
        {
            var state = await _context.Statements.FirstOrDefaultAsync(x => x.Id == id);
            if (state == null)
            {
                return NotFound();
            }
            _context.Statements.Remove(state);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
