﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Controllers
{
    [ApiController]
    [Route("/api/weeks")]
    public class WeekController:ControllerBase
    {
        private readonly DataContext _context;

        public WeekController(DataContext context)
        {
           _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.WeekWorkeds
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var week = await _context.WeekWorkeds
                .FirstOrDefaultAsync(c => c.Id == id);
            if (week == null)
            {
                return NotFound();
            }
            return Ok(week);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(WeekWorked week)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    week.Created = DateTime.Now;
                    _context.WeekWorkeds.Add(week);
                    await _context.SaveChangesAsync();
                    return Ok(week);
                }catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(WeekWorked week)
        {
            if (ModelState.IsValid)
            {
                _context.WeekWorkeds.Update(week);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                    {
                        return BadRequest($"There is an country with the same Number : < {week.WeekNumber} >");
                    }
                    return BadRequest(dbUpdateException.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(week);
        }
        //Always { } in the rute sebastian!!!
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var week = await _context.WeekWorkeds.FirstOrDefaultAsync(x => x.Id == id);
            if (week == null)
            {
                return NotFound();
            }
            _context.WeekWorkeds.Remove(week);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
