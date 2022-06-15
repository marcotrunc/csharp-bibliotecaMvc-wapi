using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csharp_bibliotecaMvc.Data;
using csharp_bibliotecaMvc.Models;

namespace csharp_bibliotecaMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresBibliotecaApiController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public AutoresBibliotecaApiController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/AutoresBibliotecaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autore>>> GetAutores()
        {
          if (_context.Autores == null)
          {
              return NotFound();
          }
            return await _context.Autores.ToListAsync();
        }

        // GET: api/AutoresBibliotecaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autore>> GetAutore(int id)
        {
          if (_context.Autores == null)
          {
              return NotFound();
          }
            var autore = await _context.Autores.FindAsync(id);

            if (autore == null)
            {
                return NotFound();
            }

            return autore;
        }

        // PUT: api/AutoresBibliotecaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutore(int id, Autore autore)
        {
            if (id != autore.AutoreID)
            {
                return BadRequest();
            }

            _context.Entry(autore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoreExists(id))
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

        // POST: api/AutoresBibliotecaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autore>> PostAutore(Autore autore)
        {
          if (_context.Autores == null)
          {
              return Problem("Entity set 'BibliotecaContext.Autores'  is null.");
          }
            _context.Autores.Add(autore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutore", new { id = autore.AutoreID }, autore);
        }

        // DELETE: api/AutoresBibliotecaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutore(int id)
        {
            if (_context.Autores == null)
            {
                return NotFound();
            }
            var autore = await _context.Autores.FindAsync(id);
            if (autore == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoreExists(int id)
        {
            return (_context.Autores?.Any(e => e.AutoreID == id)).GetValueOrDefault();
        }
    }
}
