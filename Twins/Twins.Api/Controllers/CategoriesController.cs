using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryGetAsycn()
        {
            return Ok(await _context.Categories.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> CategoryGetAsycn(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x=>x.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryPostAsync(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an Category with the same Name : < {category.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }                
            }
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> CategoryPutAsync(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an Category with the same Name : < {category.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(category);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> CategoryDeleteAsycn(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
