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
    public class InvSuplidorsController : ControllerBase
    {
        private readonly SistemaGeContext _context;

        public InvSuplidorsController(SistemaGeContext context)
        {
            _context = context;
        }

        // GET: api/InvSuplidors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvSuplidor>>> GetInvSuplidors()
        {
            return await _context.InvSuplidors.ToListAsync();
        }

        // GET: api/InvSuplidors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvSuplidor>> GetInvSuplidor(int id)
        {
            var invSuplidor = await _context.InvSuplidors.FindAsync(id);

            if (invSuplidor == null)
            {
                return NotFound();
            }

            return invSuplidor;
        }

        // PUT: api/InvSuplidors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvSuplidor(int id, InvSuplidor invSuplidor)
        {
            if (id != invSuplidor.IdSuplidor)
            {
                return BadRequest();
            }

            _context.Entry(invSuplidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvSuplidorExists(id))
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

        // POST: api/InvSuplidors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvSuplidor>> PostInvSuplidor(InvSuplidor invSuplidor)
        {
            _context.InvSuplidors.Add(invSuplidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvSuplidor", new { id = invSuplidor.IdSuplidor }, invSuplidor);
        }

        // DELETE: api/InvSuplidors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvSuplidor(int id)
        {
            var invSuplidor = await _context.InvSuplidors.FindAsync(id);
            if (invSuplidor == null)
            {
                return NotFound();
            }

            _context.InvSuplidors.Remove(invSuplidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvSuplidorExists(int id)
        {
            return _context.InvSuplidors.Any(e => e.IdSuplidor == id);
        }
    }
}
