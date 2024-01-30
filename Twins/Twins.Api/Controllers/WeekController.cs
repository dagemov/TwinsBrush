using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
                .Include(w=>w.Days)
                .ToListAsync());
        }
        /*[HttpGet("{id:int}")]
        public async Task<IActionResult> GetSumHourPerWeek(List<Day> days)
        {
            /*var days = await _context.Days
                .ToListAsync();/// comentar esto
            //var sum= new TimeSpan();
            float sum=0;
            for (int i = 1; i < 7; i++)
            {
                sum += Convert.ToDateTime( days[i].TotalHours).Hour;
            }
            Convert.ToDateTime(sum);
            return Ok(sum);
        }*/

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var week = await _context.WeekWorkeds
                .Include(w=>w.Days!)
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
