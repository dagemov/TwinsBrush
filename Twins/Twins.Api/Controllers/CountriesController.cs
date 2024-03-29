﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CountryGetAsync()
        {
            return Ok(await _context.Countries
                .Include(c=>c.States)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> CountryGetAsync(int id)
        {
            var country =  await _context.Countries
                .Include(c=>c.States!)
                .ThenInclude(c=>c.Cities!)
                .ThenInclude(c=>c.Streets)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
        [HttpPost]
        public async Task<IActionResult> CountryPostAsync(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException dbUpdateException)
                {
                    if(dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an country with the same Name : < {country.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(country);
        }
        [HttpPut]
        public async Task<IActionResult> CountryPutAsync(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Update(country);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an country with the same Name : < {country.Name} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(country);
        }
        //Always { } in the rute sebastian!!!
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> CountryDeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x=>x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
