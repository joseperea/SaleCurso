﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sale.API.Data;
using Sale.Shared.Entities;

namespace Sale.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Countries.Include(x => x.States).ToListAsync());
        }

        [HttpGet]
        [Route("Full")]
        public async Task<ActionResult> GetFullAsync()
        {
            return Ok(await _context.Countries
                .Include(x => x.States!)
                .ThenInclude(x => x.Cities)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var country = await _context.Countries
                .Include(x => x.States!)
                .ThenInclude(x => x.Cities)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (country is null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mimso nombre ");
                }

                return BadRequest(dbUpdateException.Message);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            _context.Update(country);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mimso nombre ");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(t => t.Id == id);
            if (country is null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
