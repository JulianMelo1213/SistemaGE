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
    public class InvAlmacensController : ControllerBase
    {
        private readonly SistemaGeContext _context;

        public InvAlmacensController(SistemaGeContext context)
        {
            _context = context;
        }

        // GET: api/InvAlmacens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvAlmacen>>> GetInvAlmacens()
        {
            return await _context.InvAlmacens.ToListAsync();
        }

        // GET: api/InvAlmacens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvAlmacen>> GetInvAlmacen(int id)
        {
            var invAlmacen = await _context.InvAlmacens.FindAsync(id);

            if (invAlmacen == null)
            {
                return NotFound();
            }

            return invAlmacen;
        }

        // PUT: api/InvAlmacens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvAlmacen(int id, InvAlmacen invAlmacen)
        {
            if (id != invAlmacen.IdAlmacen)
            {
                return BadRequest();
            }

            _context.Entry(invAlmacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvAlmacenExists(id))
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

        // POST: api/InvAlmacens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvAlmacen>> PostInvAlmacen(InvAlmacen invAlmacen)
        {
            _context.InvAlmacens.Add(invAlmacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvAlmacen", new { id = invAlmacen.IdAlmacen }, invAlmacen);
        }

        // DELETE: api/InvAlmacens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvAlmacen(int id)
        {
            var invAlmacen = await _context.InvAlmacens.FindAsync(id);
            if (invAlmacen == null)
            {
                return NotFound();
            }

            _context.InvAlmacens.Remove(invAlmacen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvAlmacenExists(int id)
        {
            return _context.InvAlmacens.Any(e => e.IdAlmacen == id);
        }
    }
}
