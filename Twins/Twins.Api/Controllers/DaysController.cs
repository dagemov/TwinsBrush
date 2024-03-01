using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Api.Helpers;
using Twins.Shared.DTOs;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/days")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DaysController : ControllerBase
    {
        private readonly DataContext _context;

        public DaysController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("totalPages")]
        public async Task<IActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Days.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.StartDay.ToString()!.Contains(pagination.Filter.ToLower()));

            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Days
                .AsQueryable();
            if (queryable is null)
            {
                return BadRequest();
            }
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.StartDay.ToString()!.ToLower().Contains(pagination.Filter.ToLower()));
            }
            return Ok(await queryable
                .OrderBy(x=>x.StartDay)
                .Paginate(pagination)
                .ToListAsync());
            //return Ok(await _context.Days.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var Days = await _context.Days.FirstOrDefaultAsync(d => d.Id == id);
            if (Days == null)
            {
                return NotFound();
            }
            return Ok(Days);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Day day)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Days.Add(day);
                    await _context.SaveChangesAsync();
                    return Ok(day);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return Ok(day);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Day day)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Days.Update(day);
                    await _context.SaveChangesAsync();
                    return Ok(day);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return Ok(day);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Days = await _context.Days.FirstOrDefaultAsync(d => d.Id == id);
            if (Days == null)
            {
                return NotFound();
            }
            _context.Days.Remove(Days);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
