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
        static List<Models.Comanda> comandas = new List<Models.Comanda>
        {
            new Models.Comanda
            {
                 Id = 1,
                 NomeCliente = "Jairo",
                 NumeroMesa = 1,
                 Itens = new List<ComandaItem>
                 {
                     new ComandaItem
                     {
                         Id = 1,
                         CardapioItemId = 1,
                         ComandaId = 1,
                     }
                 }
                
            },
            new Models.Comanda
            {
                Id = 2,
                 NomeCliente = "Pedro",
                 NumeroMesa = 2,
                 Itens = new List<ComandaItem>
                 {
                     new ComandaItem
                     {
                         Id = 2,
                         CardapioItemId = 2,
                         ComandaId = 1,
                     }
                 }
             
            }
        };
        // GET: api/<ComandaController>
        [HttpGet]
        public IResult Get()
        {
            return Results.Ok(comandas);
        }

        // GET api/<ComandaController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var comanda = comandas.FirstOrDefault(x => x.Id == id);
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
                Id = comandas.Count + 1,
                NomeCliente = comandaCreate.NomeCliente,
                NumeroMesa = comandaCreate.NumeroMesa
            };
            var comandaItens = new List<ComandaItem>();
            foreach (int cardapioItemds in comandaCreate.CardapioItemds)
            {
                var comandaItem = new ComandaItem
                {
                    Id = comandaItens.Count + 1,
                    CardapioItemId = cardapioItemds,
                    ComandaId = novaComanda.Id,
                };
                comandaItens.Add(comandaItem);
            }
            novaComanda.Itens = comandaItens;
          
                comandas.Add(novaComanda);
            return Results.Created($"/api/comanda/{novaComanda.Id}", novaComanda);
        }

        // PUT api/<ComandaController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] ComandaUpdateResquest comandaUpdate)
        {
            var comanda = comandas.FirstOrDefault(c => c.Id == id);
            if (comanda is null)
                return Results.NotFound("Comanda não encontrada.");
            if(comandaUpdate.NomeCliente.Length < 3)
                return Results.BadRequest("O numero do cliente deve ter no mínimo 3 caracteres.");
            if (comandaUpdate.NumeroMesa <=0)
                return Results.BadRequest("O numero da mesa deve ser maior que zero.");
            comanda.NumeroMesa = comandaUpdate.NumeroMesa;
            comanda.NomeCliente = comandaUpdate.NomeCliente;

               comandas.Add(comanda);
            return Results.NoContent();

        }

        // DELETE api/<ComandaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
