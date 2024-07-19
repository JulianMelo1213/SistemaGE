using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGE.Models;

namespace SistemaGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvArticuloSuplidorsController : ControllerBase
    {
        private readonly SistemaGeContext _context;

        public InvArticuloSuplidorsController(SistemaGeContext context)
        {
            _context = context;
        }

        // GET: api/InvArticuloSuplidors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvArticuloSuplidor>>> GetInvArticuloSuplidors()
        {
            return await _context.InvArticuloSuplidors.ToListAsync();
        }

        // GET: api/InvArticuloSuplidors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvArticuloSuplidor>> GetInvArticuloSuplidor(int id)
        {
            var invArticuloSuplidor = await _context.InvArticuloSuplidors.FindAsync(id);

            if (invArticuloSuplidor == null)
            {
                return NotFound();
            }

            return invArticuloSuplidor;
        }

        // PUT: api/InvArticuloSuplidors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvArticuloSuplidor(int id, InvArticuloSuplidor invArticuloSuplidor)
        {
            if (id != invArticuloSuplidor.IdArticuloSuplidor)
            {
                return BadRequest();
            }

            _context.Entry(invArticuloSuplidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvArticuloSuplidorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InvArticuloSuplidors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvArticuloSuplidor>> PostInvArticuloSuplidor(InvArticuloSuplidor invArticuloSuplidor)
        {
            _context.InvArticuloSuplidors.Add(invArticuloSuplidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvArticuloSuplidor", new { id = invArticuloSuplidor.IdArticuloSuplidor }, invArticuloSuplidor);
        }

        // DELETE: api/InvArticuloSuplidors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvArticuloSuplidor(int id)
        {
            var invArticuloSuplidor = await _context.InvArticuloSuplidors.FindAsync(id);
            if (invArticuloSuplidor == null)
            {
                return NotFound();
            }

            _context.InvArticuloSuplidors.Remove(invArticuloSuplidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvArticuloSuplidorExists(int id)
        {
            return _context.InvArticuloSuplidors.Any(e => e.IdArticuloSuplidor == id);
        }
    }
}
