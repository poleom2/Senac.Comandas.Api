using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comanda.Api;
using Comanda.Api.Models;

namespace Comanda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly ComandaDbContext _context;

        public ReservasController(ComandaDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // PUT: api/Reservas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reserva)
        {
            if (id != reserva.id)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;
            var novaMesa = await _context.Mesas.FirstOrDefaultAsync(nm => nm.NumeroMesa == reserva.NumeroMesa);
            if (novaMesa is null) { 
                return BadRequest("Mesa Não encontrada.");
            }
            novaMesa.SituacaoMesa = (int) SituacaoMesa.Reservada;
            var reservaOriginal = await _context.Reservas.AsNoTracking().FirstOrDefaultAsync(r => r.id == id);
            var numerpMesaOriginal = reservaOriginal!.NumeroMesa;
            var MesaOriginal = await _context.Mesas.FirstOrDefaultAsync(m => m.NumeroMesa == numerpMesaOriginal);
                MesaOriginal!.SituacaoMesa = (int) SituacaoMesa.Livre;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reservas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            var mesa = await _context.Mesas.FirstOrDefaultAsync(m =>m.NumeroMesa == reserva.NumeroMesa);
            if (mesa is not null)
            {
             if (mesa is null)
                    return BadRequest("Mesa não encontrada");
             if(mesa.SituacaoMesa != (int) SituacaoMesa.Livre)
                {
                    return BadRequest("Mesa não esta disponivel para reserva.");
                }
                mesa.SituacaoMesa = (int)SituacaoMesa.Reservada;

            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { id = reserva.id }, reserva);
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound("Reserva naõ encontrado");
            }
            var mesa = await _context.Mesas.FirstOrDefaultAsync(m => m.NumeroMesa== reserva.NumeroMesa);
            if (mesa is  null)
            {
                return BadRequest("Mesa não encontrada");
            }

            mesa.SituacaoMesa = (int)SituacaoMesa.Livre;
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.id == id);
        }
    }
}
