using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.DTOs;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/servicesCustomer")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServicesCustomerController : ControllerBase
    {
        private readonly DataContext _context;
        public ServicesCustomerController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("totalPages")]
        public async Task<IActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.ServiceCustomers.AsQueryable();

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
            var Customers = await _context.ServiceCustomers
                .Include(u => u.User)
                .Include(s => s.Service)
                .ToListAsync();
            if (Customers == null)
            {
                return BadRequest("No records to show");
            }
            return Ok(Customers);
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
            var ServiceCustomers = await _context.ServiceCustomers
                .Include(u => u.User)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(su => su.Id == id);
            if (ServiceCustomers == null)
            {
                return NotFound();
            }
            return Ok(ServiceCustomers);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var CustomerSelect = await _context.ServiceCustomers.FirstOrDefaultAsync(e => e.Id == id);
            if (CustomerSelect == null)
            {
                return NotFound();
            }
            _context.ServiceCustomers.Remove(CustomerSelect);
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
