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
    public class InvArticuloesController : ControllerBase
    {
        private readonly SistemaGeContext _context;

        public InvArticuloesController(SistemaGeContext context)
        {
            _context = context;
        }

        // GET: api/InvArticuloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvArticulo>>> GetInvArticulos()
        {
            return await _context.InvArticulos.ToListAsync();
        }

        // GET: api/InvArticuloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvArticulo>> GetInvArticulo(int id)
        {
            var invArticulo = await _context.InvArticulos.FindAsync(id);

            if (invArticulo == null)
            {
                return NotFound();
            }

            return invArticulo;
        }

        // PUT: api/InvArticuloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvArticulo(int id, InvArticulo invArticulo)
        {
            if (id != invArticulo.IdArticulo)
            {
                return BadRequest();
            }

            _context.Entry(invArticulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvArticuloExists(id))
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

        // POST: api/InvArticuloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvArticulo>> PostInvArticulo(InvArticulo invArticulo)
        {
            _context.InvArticulos.Add(invArticulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvArticulo", new { id = invArticulo.IdArticulo }, invArticulo);
        }

        // DELETE: api/InvArticuloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvArticulo(int id)
        {
            var invArticulo = await _context.InvArticulos.FindAsync(id);
            if (invArticulo == null)
            {
                return NotFound();
            }

            _context.InvArticulos.Remove(invArticulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvArticuloExists(int id)
        {
            return _context.InvArticulos.Any(e => e.IdArticulo == id);
        }
    }
}
