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
    public class InvUbicacionsController : ControllerBase
    {
        private readonly SistemaGeContext _context;

        public InvUbicacionsController(SistemaGeContext context)
        {
            _context = context;
        }

        // GET: api/InvUbicacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvUbicacion>>> GetInvUbicacions()
        {
            return await _context.InvUbicacions.ToListAsync();
        }

        // GET: api/InvUbicacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvUbicacion>> GetInvUbicacion(int id)
        {
            var invUbicacion = await _context.InvUbicacions.FindAsync(id);

            if (invUbicacion == null)
            {
                return NotFound();
            }

            return invUbicacion;
        }

        // PUT: api/InvUbicacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvUbicacion(int id, InvUbicacion invUbicacion)
        {
            if (id != invUbicacion.IdUbicacion)
            {
                return BadRequest();
            }

            _context.Entry(invUbicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvUbicacionExists(id))
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

        // POST: api/InvUbicacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvUbicacion>> PostInvUbicacion(InvUbicacion invUbicacion)
        {
            _context.InvUbicacions.Add(invUbicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvUbicacion", new { id = invUbicacion.IdUbicacion }, invUbicacion);
        }

        // DELETE: api/InvUbicacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvUbicacion(int id)
        {
            var invUbicacion = await _context.InvUbicacions.FindAsync(id);
            if (invUbicacion == null)
            {
                return NotFound();
            }

            _context.InvUbicacions.Remove(invUbicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvUbicacionExists(int id)
        {
            return _context.InvUbicacions.Any(e => e.IdUbicacion == id);
        }
    }
}
