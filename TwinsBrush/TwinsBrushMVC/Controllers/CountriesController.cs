using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwinsBrushMVC.Data;
using TwinsBrushMVC.Data.Entities;

namespace TwinsBrushMVC.Controllers
{
    public class CountriesController : Controller
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Countries
                .Include(c=>c.States)
                .ThenInclude(c=>c.Cities)
                .ThenInclude(c=>c.Streets)
                .ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            Country country = new()
            {
                States = new List<State>(),
            };
            return PartialView("_AddCountry",country);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> CountryCreate()
        {
            Country country = new()
            {
                States = new List<State>(),
            };
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CountryCreate(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                try
                {
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There is already a country with this name");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(country);
        }
        [HttpGet]
        public async Task<IActionResult> CountryDetails(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var country = _context.Countries
                 .Include(c => c.States)
                .ThenInclude(c => c.Cities)
                .ThenInclude(c=>c.Streets)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpGet]
        public async Task<IActionResult> CountryDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var country = _context.Countries
                .Include(c=>c.States)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country) ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CountryDelete(int id)
        {
            if (_context.Countries == null)
            {
                return Problem("Entity set 'DataContext.Countries'  is null.");
            }
            var country = await _context.Countries.FindAsync(id);
            if(country == null)
            {
                return NotFound();
            }
            else
            {
                _context.Countries.Remove(country);
            }        
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> CountryEdit (int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var country = _context.Countries
                .FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpPost]
        public async Task<IActionResult> CountryEdit(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Update(country);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
                {

                }
            }
            return View(country);
        }

    }
}
