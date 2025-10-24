using Comanda.Api.DTOs;
using Comanda.Api.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comanda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        public ComandaDbContext _context { get; set; }
        public MesaController(ComandaDbContext context) 
        {
            _context = context;
        }



        // GET: api/<MesaController>
        [HttpGet]
        public IResult GetMesa()
        {
            var mesas = _context.Mesas.ToList();
            return Results.Ok(mesas);
        }

        // GET api/<MesaController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var mesa = _context.Mesas.FirstOrDefault(m => m.Id == id);
            if (mesa == null)
            {
                return Results.NotFound("Mesa não encontrada!");
            }
            return Results.Ok(mesa);
        }

        // POST api/<MesaController>
        [HttpPost]
        public IResult Post([FromBody] MesaCreateResquest mesaCreate)
        {
            if (mesaCreate.NumeroMesa <= 0)
            {
                return Results.BadRequest("O numero da mesa deve ser maior que zero.");
            }
            var mesa = new Mesa
            {
                NumeroMesa = mesaCreate.NumeroMesa,
                SituacaoMesa = mesaCreate.SituacaoMesa,
            };
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return Results.Created($"/api/mesa/{mesa.Id}", mesa);

        }

        // PUT api/<MesaController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] MesaUpdateresquest mesaUpdate)
        {
            var mesa = _context.Mesas.FirstOrDefault(m => m.Id == m.Id);
            if (mesa is null)
                return Results.NotFound($"Mesa do Não encontrado.");
            mesa.SituacaoMesa = mesaUpdate.SituacaoMesa;
            mesa.NumeroMesa = mesaUpdate.NumeroMesa;
            _context.SaveChanges();
            return Results.Ok(mesa);
        }

        // DELETE api/<MesaController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var mesa = _context.Mesas.FirstOrDefault(me => me.Id == id);
            if (mesa is null) 
                return Results.NotFound($"Mesa com o id {id} não encontrada!");
            _context.Remove(mesa);
            var mesamovida = _context.SaveChanges() > 0;
            if (mesamovida)
                return Results.NoContent();
            return Results.StatusCode(500);

        }
    }
}
