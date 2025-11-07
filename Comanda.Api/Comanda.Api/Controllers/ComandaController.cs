using Comanda.Api.DTOs;
using Comanda.Api.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comanda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        public ComandaDbContext _context { get; set; }
        public ComandaController(ComandaDbContext context) 
        {
            _context = context;
        }

        // GET: api/<ComandaController>
        [HttpGet]
        public IResult Get()
        {
            var comandas = _context.Comandas.ToList();
            return Results.Ok(comandas);
        }

        // GET api/<ComandaController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var comanda = _context.Comandas.FirstOrDefault(x => x.Id == id);
            if (comanda == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(comanda);
        }

        // POST api/<ComandaController>
        [HttpPost]
        public IResult Post([FromBody] ComandaCreateResquest comandaCreate)
        {
            if (comandaCreate.NomeCliente.Length < 3)
            {
                return Results.BadRequest("O numero do cliente deve ter no mínimo 3 caracteres.");
            }
            if (comandaCreate.NumeroMesa <= 0)
            {
                return Results.BadRequest("O numero da mesa deve ser maior que zero.");

            }
            if (comandaCreate.CardapioItemds.Length == 0)
            {
                return Results.BadRequest("A comanda deve ter pelo menos um item do cardapio.");
            }

            var novaComanda = new Models.Comanda

            {
           
                NomeCliente = comandaCreate.NomeCliente,
                NumeroMesa = comandaCreate.NumeroMesa
            };
            var comandaItens = new List<ComandaItem>();
            foreach (var cardapioItemds in comandaCreate.CardapioItemds)
            {
                var comandaItem = new ComandaItem
                {
                
                    CardapioItemId = cardapioItemds,
                    Comanda= novaComanda,
                };
                comandaItens.Add(comandaItem);
                var cardapioItem = _context.CardapioItens.FirstOrDefault(c => c.Id == cardapioItemds);
                if (cardapioItem!.PossuiPreparo)
                {
                    var pedido = new PedidoCozinha
                    {
                        Comanda = novaComanda,
                    };
                    var pedidoIten = new PedidoCozinhaItem
                    {
                        ComandaItem = comandaItem,
                        PedidoCozinha = pedido

                    };
                    _context.PedidosCozinhas.Add(pedido);
                    _context.PedidosCozinhaItens.Add(pedidoIten);

                }
            }
            novaComanda.Itens = comandaItens;
          
                _context.Comandas.Add(novaComanda);
            _context.SaveChanges();
            var response = new comandaCrestrResponse
            {
                id = novaComanda.Id,
                NomeCliente = novaComanda.NomeCliente,
                NumeroMesa = novaComanda.NumeroMesa,
                Itens = novaComanda.Itens.Select(i => new ComandaItemResponse
                {
                    Id = i.Id,
                    Titulo = _context.CardapioItens.First(ci => ci.Id == i.CardapioItemId).Titulo
                }).ToList(),

            };
            return Results.Created($"/api/comanda/{response.id}", response);
        }

        // PUT api/<ComandaController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] ComandaUpdateResquest comandaUpdate)
        {
            var comanda = _context.Comandas.FirstOrDefault(c => c.Id == id);
            if (comanda is null)
                return Results.NotFound("Comanda não encontrada.");
            if(comandaUpdate.NomeCliente.Length < 3)
                return Results.BadRequest("O numero do cliente deve ter no mínimo 3 caracteres.");
            if (comandaUpdate.NumeroMesa <=0)
                return Results.BadRequest("O numero da mesa deve ser maior que zero.");
            comanda.NumeroMesa = comandaUpdate.NumeroMesa;
            comanda.NomeCliente = comandaUpdate.NomeCliente;

               _context.Comandas.Add(comanda);
            _context.SaveChanges();
            return Results.NoContent();

        }

        // DELETE api/<ComandaController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var comanda = _context.Comandas.FirstOrDefault(c => c.Id == id);
            if (comanda is null)
            return Results.NotFound("Comanda não encontrada!");
            _context.Comandas.Remove(comanda);
            var comandaReovida = _context.SaveChanges() > 0;
            if (comandaReovida)
                return Results.NoContent();
            return Results.StatusCode(500);
            
        }
    }
}
