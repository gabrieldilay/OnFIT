using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;

namespace OnFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly Context _context;

        public EquipamentoController(Context context)
        {
            _context = context;
        }

        // GET: api/Equipamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipamento>>> GetEquipamento()
        {
            return await _context.Equipamentos.ToListAsync();
        }

        // GET: api/Equipamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipamento>> GetEquipamento(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return equipamento;
        }

        // PUT: api/Equipamento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipamento(int id, Equipamento equipamento)
        {
            if (id != equipamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentoExists(id))
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

        // POST: api/Equipamento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipamento>> PostEquipamento(Equipamento equipamento)
        {
            _context.Equipamentos.Add(equipamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipamento", new { id = equipamento.Id }, equipamento);
        }

        // DELETE: api/Equipamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamento(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }

            _context.Equipamentos.Remove(equipamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipamentoExists(int id)
        {
            return _context.Equipamentos.Any(e => e.Id == id);
        }
    }
}
