using Comanda.Api.DTOs;
using Comanda.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comanda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoCozinhaController : ControllerBase
    {
        public ComandaDbContext _context { get; set; }

        public PedidoCozinhaController(ComandaDbContext context)
        {
            _context = context;
        }
        // GET: api/<PedidoCozinhaController>
        [HttpGet]
        public IResult Get()
        {
            var pedidos = _context.PedidosCozinhas.ToList();
            return Results.Ok(pedidos);
        }

        // GET api/<PedidoCozinhaController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var pedid = _context.PedidosCozinhas.FirstOrDefault(p=> p.id == id);
            if (pedid == null)
            {
                return Results.NotFound("Pedido não encontrado!");
            }
            _context.SaveChanges();
            return Results.Ok(pedid);
        }

        // POST api/<PedidoCozinhaController>
        [HttpPost]
        public IResult Post([FromBody] PedidocozinhaCreateRequest pedidocozinhaCreate)
        {
            var novoPedidoCozinha = new PedidoCozinha
            {
               
                ComandaId = pedidocozinhaCreate.ComandaId,

            };
            var pedidosItem = new List<PedidoCozinhaItem>();
            foreach (var item in pedidocozinhaCreate.items)
            {
                var pedidoItem = new PedidoCozinhaItem
                {
                   
                    ComandaItemId = item.ComandaItemId,
                    PedidoCozinhaId = item.PedidoCozinhaid
                };
                pedidosItem.Add(pedidoItem);
            }

            novoPedidoCozinha.items = pedidosItem ;

            _context.PedidosCozinhas.Add(novoPedidoCozinha);
            _context.SaveChanges();
            return Results.Created($"/api/PedidoCozinha/{novoPedidoCozinha.id}", novoPedidoCozinha);
        
        }

       


        // PUT api/<PedidoCozinhaController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] PedidocozinhaUpdateRequest pedidocozinhaUpdate)
        {
            var cpedido = _context.PedidosCozinhas.FirstOrDefault(p => p.id == id);
           if (cpedido is null)
               return Results.NotFound("Pedido não encontado!");
           cpedido.ComandaId = pedidocozinhaUpdate.ComandaId;
            var pedidosItem = new List<PedidoCozinhaItem>();
            foreach (var item in pedidocozinhaUpdate.items)
            {
                var pedidoItem = new PedidoCozinhaItem
                {

                    ComandaItemId = item.ComandaItemId,
                    PedidoCozinhaId = item.PedidoCozinhaid
                };
                pedidosItem.Add(pedidoItem);
            }
            cpedido.items = pedidosItem;
            _context.SaveChanges();
            return Results.Ok(cpedido);

        }

        // DELETE api/<PedidoCozinhaController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var pedidocozinha = _context.PedidosCozinhas.FirstOrDefault(p => p.id == id);
            if (pedidocozinha is null)
                return Results.NotFound("Pedido não encontrado!");
            _context.PedidosCozinhas.Remove(pedidocozinha);
            _context.SaveChanges();
            return Results.NoContent();

        }
    }
}
