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
    public class InvTipoDocumentoesController : ControllerBase
    {
        private readonly SistemaGeContext _context;

        public InvTipoDocumentoesController(SistemaGeContext context)
        {
            _context = context;
        }

        // GET: api/InvTipoDocumentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvTipoDocumento>>> GetInvTipoDocumentos()
        {
            return await _context.InvTipoDocumentos.ToListAsync();
        }

        // GET: api/InvTipoDocumentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvTipoDocumento>> GetInvTipoDocumento(int id)
        {
            var invTipoDocumento = await _context.InvTipoDocumentos.FindAsync(id);

            if (invTipoDocumento == null)
            {
                return NotFound();
            }

            return invTipoDocumento;
        }

        // PUT: api/InvTipoDocumentoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvTipoDocumento(int id, InvTipoDocumento invTipoDocumento)
        {
            if (id != invTipoDocumento.IdTipoDocumento)
            {
                return BadRequest();
            }

            _context.Entry(invTipoDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvTipoDocumentoExists(id))
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

        // POST: api/InvTipoDocumentoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvTipoDocumento>> PostInvTipoDocumento(InvTipoDocumento invTipoDocumento)
        {
            _context.InvTipoDocumentos.Add(invTipoDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvTipoDocumento", new { id = invTipoDocumento.IdTipoDocumento }, invTipoDocumento);
        }

        // DELETE: api/InvTipoDocumentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvTipoDocumento(int id)
        {
            var invTipoDocumento = await _context.InvTipoDocumentos.FindAsync(id);
            if (invTipoDocumento == null)
            {
                return NotFound();
            }

            _context.InvTipoDocumentos.Remove(invTipoDocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvTipoDocumentoExists(int id)
        {
            return _context.InvTipoDocumentos.Any(e => e.IdTipoDocumento == id);
        }
    }
}
