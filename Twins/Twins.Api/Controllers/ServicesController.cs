using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Twins.Api.Data;
using Twins.Api.Helpers;
using Twins.Shared.DTOs;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/services")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServicesController : ControllerBase
    {
        private readonly DataContext _context;

        public ServicesController(DataContext conext)
        {
            _context = conext;
        }

        [HttpGet("totalPages")]
        public async Task<IActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Services.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));

            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Services
                .Include(w => w.WeekWorked)
                .Include(u => u.Users)
                .Include(picture => picture.Pictures)
                .AsQueryable();
            if (queryable is null)
            {
                return BadRequest();
            }
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Created.ToString()!.ToLower().Contains(pagination.Filter.ToLower()));
            }
            return Ok(await queryable
                .OrderBy(s => s.Name)
                .Paginate(pagination)
                .ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ServicesGetAsync(int id)
        {
            var service = await _context.Services
                .Include(w => w.WeekWorked)
                .Include(u => u.Users)
                .Include(picture => picture.Pictures)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                service.Created = DateTime.Now;
                try
                {
                    await _context.SaveChangesAsync();
                } catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(service);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(service);
                service.Updated = DateTime.Now;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(service);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsycn(int id)
        {
            var service = await _context.Services
                 .FirstOrDefaultAsync(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("AddEmployed")]
        public async Task<IActionResult> AddEmployedService( [FromBody] AddEmployeedUserDTO user, [FromQuery] int id)
        {
            if (user == null)
            {
                return NotFound();
            }
           
            if (user.UserType == UserType.Employed || user.UserType == UserType.Mannager)
            {
                ServiceUser serviceUser = new()
                {
                    UserId = user.Id,
                    User = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email),
                    EmployedDocument = user.Documment,
                    ServiceId = id,
                    Service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id),
                    Register = true,
                };
                await _context.ServiceUsers.AddAsync(serviceUser);
                try
                {                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"Is Alredy exist one employeed with this document in this service \n : < {user.Documment} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("The User must be Emplooyed User ");
            }
            return Ok(user);
        }
        
        
        
    }
}
