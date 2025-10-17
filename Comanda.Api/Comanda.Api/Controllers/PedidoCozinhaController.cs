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
        List<PedidoCozinha> pedidos = new List<PedidoCozinha>()
        {
            new PedidoCozinha
            {
                id = 1,
                ComandaId = 1,

            },
            new PedidoCozinha
            {
                id = 2,
                ComandaId = 2,
            }
        };

        // GET: api/<PedidoCozinhaController>
        [HttpGet]
        public IResult Get()
        {
            return Results.Ok(pedidos);
        }

        // GET api/<PedidoCozinhaController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var pedid = pedidos.FirstOrDefault(p=> p.id == id);
            if (pedid == null)
            {
                return Results.NotFound("Pedido não encontrado!");
            }
            return Results.Ok(pedid);
        }

        // POST api/<PedidoCozinhaController>
        [HttpPost]
        public IResult Post([FromBody] PedidocozinhaCreateRequest pedidocozinhaCreate)
        {
            var novoPedidoCozinha = new PedidoCozinha
            {
                id = pedidos.Count + 1,
                ComandaId = pedidocozinhaCreate.ComandaId,

            };
            var pedidosItem = new List<PedidoCozinhaItem>();
            foreach (var item in pedidocozinhaCreate.items)
            {
                var pedidoItem = new PedidoCozinhaItem
                {
                    Id = pedidos.Count + 1,
                    ComandaItemId = item.ComandaItemId,
                    PedidoCozinhaId = item.PedidoCozinhaid
                };
                pedidosItem.Add(pedidoItem);
            }

            novoPedidoCozinha.items = pedidosItem ;

            pedidos.Add(novoPedidoCozinha);
            return Results.Created($"/api/PedidoCozinha/{novoPedidoCozinha.id}", novoPedidoCozinha);
        
        }

       


        // PUT api/<PedidoCozinhaController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] PedidocozinhaUpdateRequest pedidocozinhaUpdate)
        {
            var cpedido = pedidos.FirstOrDefault(p => p.id == id);
            if (cpedido is null)
                return Results.NotFound("Pedido não encontado!");
                cpedido.ComandaId = pedidocozinhaUpdate.ComandaId;
                

            
        }

        // DELETE api/<PedidoCozinhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
