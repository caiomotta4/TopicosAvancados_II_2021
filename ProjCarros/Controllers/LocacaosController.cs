using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjCarros.Data;
using ProjCarros.Model;

namespace ProjCarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaosController : ControllerBase
    {
        private readonly ProjCarrosContext _context;

        public LocacaosController(ProjCarrosContext context)
        {
            _context = context;
        }

        // GET: api/Locacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> GetLocacao()
        {
            return await _context.Locacao.ToListAsync();
        }

        // GET: api/Locacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> GetLocacao(int id)
        {
            var locacao = await _context.Locacao.FindAsync(id);

            if (locacao == null)
            {
                return NotFound();
            }

            return locacao;
        }

        // PUT: api/Locacaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocacao(int id, Locacao locacao)
        {
            if (id != locacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(locacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
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

        // POST: api/Locacaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locacao>> PostLocacao(Locacao locacao)
        {
            _context.Locacao.Add(locacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocacao", new { id = locacao.Id }, locacao);
        }

        // DELETE: api/Locacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocacao(int id)
        {
            var locacao = await _context.Locacao.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }

            _context.Locacao.Remove(locacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocacaoExists(int id)
        {
            return _context.Locacao.Any(e => e.Id == id);
        }
    }
}
