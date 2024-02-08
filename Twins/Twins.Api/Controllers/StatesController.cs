using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Api.Helpers;
using Twins.Shared.DTOs;
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
        [HttpGet("totalPages")]
        public async Task<IActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Statements
                .Where(x => x.Country!.Id == pagination.Id)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }


            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count/pagination.RecordsNumber);
            return Ok(totalPages);
        }
        [HttpGet]
        public async Task<IActionResult> StateGetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Statements
                .Include(s => s.Cities)
                .Where(s => s.Country!.Id == pagination.Id)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }


            return Ok( await queryable
                .OrderBy(s=>s.Name)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> StateGetAsync(int id)
        {
            var state = await _context.Statements
                .Include(s => s.Cities!)
                .ThenInclude(s=>s.Streets)
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
                
                try
                {
                    _context.Statements.Update(state);
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
