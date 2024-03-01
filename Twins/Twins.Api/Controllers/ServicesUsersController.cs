using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.DTOs;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/servicesUsers")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServicesUsersController : ControllerBase
    {
        private readonly DataContext _context;

        public ServicesUsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("totalPages")]
        public async Task<IActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.ServiceUsers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.User!.FullName.Contains(pagination.Filter.ToLower()));

            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var emplooyes = await _context.ServiceUsers
                .Include(u => u.User)
                .Include(s => s.Service)
                .ToListAsync();
            if (emplooyes == null)
            {
                return BadRequest("No records to show");
            }
            return Ok(emplooyes);
            /*
            var queryable = _context.ServiceUsers
                .Include(u => u.User)
                .Include(s => s.Service)
                .AsQueryable();
            if (queryable is null)
            {
                return BadRequest();
            }
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.User!.FullName.ToLower().Contains(pagination.Filter.ToLower()));
            }
            return Ok(await queryable
                    .OrderBy(name => name.User!.FullName)
                    .Paginate(pagination)
                    .ToListAsync()
            );*/
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetServiceUserAsync(int id)
        {
            var serviceUser = await _context.ServiceUsers
                .Include(u => u.User)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(su => su.Id == id);
            if (serviceUser == null)
            {
                return NotFound();
            }
            return Ok(serviceUser);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var emplooyedSelect = await _context.ServiceUsers.FirstOrDefaultAsync(e => e.Id == id);
            if (emplooyedSelect == null)
            {
                return NotFound();
            }
            _context.ServiceUsers.Remove(emplooyedSelect);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete {ex.Message}");
            }
            return NoContent();
        }
    }
}
