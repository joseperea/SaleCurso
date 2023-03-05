using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sale.API.Data;
using Sale.Shared.Entities;

namespace Sale.API.Controllers
{
    [ApiController]
    [Route("/api/states")]
    public class StatesController: ControllerBase
    {
        private readonly DataContext _context;
        public StatesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.States.Include(x => x.Cities).ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var State = await _context.States
                .Include(x => x.Cities)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (State is null)
            {
                return NotFound();
            }

            return Ok(State);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(State state)
        {
            _context.Add(state);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(state);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un estado/Departamento con el mimso nombre ");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(State state)
        {
            _context.Update(state);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(state);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un estado/Departamento con el mimso nombre ");
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
            var state = await _context.States.FirstOrDefaultAsync(t => t.Id == id);
            if (state is null)
            {
                return NotFound();
            }

            _context.Remove(state);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
