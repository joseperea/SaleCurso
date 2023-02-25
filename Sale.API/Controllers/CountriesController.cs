using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sale.API.Data;
using Sale.Shared.Entities;

namespace Sale.API.Controllers
{
    [ApiController]
    [Route("/api/coutries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync() 
        {
            return Ok(await _context.Countries.ToListAsync());
        }
    }
}
