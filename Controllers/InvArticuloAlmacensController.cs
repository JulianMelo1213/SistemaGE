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
    public class InvArticuloAlmacensController : ControllerBase
    {
        private readonly SistemaGeContext _context;

        public InvArticuloAlmacensController(SistemaGeContext context)
        {
            _context = context;
        }

        // GET: api/InvArticuloAlmacens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvArticuloAlmacen>>> GetInvArticuloAlmacens()
        {
            return await _context.InvArticuloAlmacens.ToListAsync();
        }

        // GET: api/InvArticuloAlmacens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvArticuloAlmacen>> GetInvArticuloAlmacen(int id)
        {
            var invArticuloAlmacen = await _context.InvArticuloAlmacens.FindAsync(id);

            if (invArticuloAlmacen == null)
            {
                return NotFound();
            }

            return invArticuloAlmacen;
        }

        // PUT: api/InvArticuloAlmacens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvArticuloAlmacen(int id, InvArticuloAlmacen invArticuloAlmacen)
        {
            if (id != invArticuloAlmacen.IdArticuloAlmacen)
            {
                return BadRequest();
            }

            _context.Entry(invArticuloAlmacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvArticuloAlmacenExists(id))
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

        // POST: api/InvArticuloAlmacens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvArticuloAlmacen>> PostInvArticuloAlmacen(InvArticuloAlmacen invArticuloAlmacen)
        {
            _context.InvArticuloAlmacens.Add(invArticuloAlmacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvArticuloAlmacen", new { id = invArticuloAlmacen.IdArticuloAlmacen }, invArticuloAlmacen);
        }

        // DELETE: api/InvArticuloAlmacens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvArticuloAlmacen(int id)
        {
            var invArticuloAlmacen = await _context.InvArticuloAlmacens.FindAsync(id);
            if (invArticuloAlmacen == null)
            {
                return NotFound();
            }

            _context.InvArticuloAlmacens.Remove(invArticuloAlmacen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvArticuloAlmacenExists(int id)
        {
            return _context.InvArticuloAlmacens.Any(e => e.IdArticuloAlmacen == id);
        }
    }
}
