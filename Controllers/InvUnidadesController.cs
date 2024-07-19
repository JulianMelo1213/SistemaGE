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
    public class InvUnidadesController : ControllerBase
    {
        private readonly SistemaGeContext _context;

        public InvUnidadesController(SistemaGeContext context)
        {
            _context = context;
        }

        // GET: api/InvUnidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvUnidade>>> GetInvUnidades()
        {
            return await _context.InvUnidades.ToListAsync();
        }

        // GET: api/InvUnidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvUnidade>> GetInvUnidade(int id)
        {
            var invUnidade = await _context.InvUnidades.FindAsync(id);

            if (invUnidade == null)
            {
                return NotFound();
            }

            return invUnidade;
        }

        // PUT: api/InvUnidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvUnidade(int id, InvUnidade invUnidade)
        {
            if (id != invUnidade.IdUnidad)
            {
                return BadRequest();
            }

            _context.Entry(invUnidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvUnidadeExists(id))
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

        // POST: api/InvUnidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvUnidade>> PostInvUnidade(InvUnidade invUnidade)
        {
            _context.InvUnidades.Add(invUnidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvUnidade", new { id = invUnidade.IdUnidad }, invUnidade);
        }

        // DELETE: api/InvUnidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvUnidade(int id)
        {
            var invUnidade = await _context.InvUnidades.FindAsync(id);
            if (invUnidade == null)
            {
                return NotFound();
            }

            _context.InvUnidades.Remove(invUnidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvUnidadeExists(int id)
        {
            return _context.InvUnidades.Any(e => e.IdUnidad == id);
        }
    }
}
