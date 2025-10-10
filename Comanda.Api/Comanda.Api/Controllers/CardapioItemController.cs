using Comanda.Api.DTOs;
using Comanda.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comanda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioItemController : ControllerBase
    {
        // GET: api/<CardapioItemControlleer>
        public List<CardapioItem> cardapios = new List<CardapioItem>
        {
            new CardapioItem {
                Id = 1, Titulo = "Coca-Cola",
                Descricao = "Refrigerante 350ml",
                Preco = 5.00M,
                PossuiPreparo = false
            },
            new CardapioItem
            {
               Id = 2,
               Titulo = "Pizza Calabresa",
               Descricao = "Pizza sabor calabresa com borda recheada",
               Preco = 40.00M,
               PossuiPreparo = true
            }
        };
        [HttpGet]
        public  IResult GetCardapio ()
        {
            return Results.Ok(cardapios);
        }
            // GET api/<CardapioItemControlleer>/5
            [HttpGet("{id}")]
            public IResult Get(int id)
            {
                var cardapio  = cardapios.FirstOrDefault(c => c.Id == id);
            if (cardapio == null)
            {
                return Results.NotFound("Cardapio não encontrado!");
            }

            return Results.Ok(cardapio);
        }

            // POST api/<CardapioItemControlleer>
            [HttpPost]
            public IResult Post([FromBody] CardapioItemCreateRequest cardapio)
            {
                if(cardapio.Titulo.Length < 3)
                {
                    return Results.BadRequest("O titulo do item cardapio deve ter no minimo 3 caracteres. ");
                }
                if (cardapio.Descricao.Length < 3)
                {

                    return Results.BadRequest("A descrição do item cardapio deve ter no minimo 3 caracteres.");
                }
                if (cardapio.Preco <= 0)
                {
                 return Results.BadRequest("O preço do item do cardapio deve ser maior a zero");
                }
            var cardapioitem = new CardapioItem
            {
                Id = cardapios.Count + 1,
                Titulo = cardapio.Titulo,
                Descricao = cardapio.Descricao,
                Preco = cardapio.Preco,
                PossuiPreparo =cardapio.PossuiPreparo,
            };
            cardapios.Add(cardapioitem);
            return Results.Created($"/api/cardapioItem/{cardapioitem.Id}", cardapio);
            }
        
        

            // PUT api/<CardapioItemControlleer>/5
            [HttpPut("{id}")]
            public IResult Put(int id, [FromBody] CardapioItemupdateResquest cardapio)
            {
            var cardapioItem = cardapios.FirstOrDefault(c => c.Id == id);
            if (cardapioItem is null)
                return Results.NotFound($"Cardapio do {id} não encontrado");
                cardapioItem.Titulo = cardapio.Titulo;
                cardapioItem.Descricao = cardapio.Descricao;
                cardapioItem.Preco = cardapio.Preco;
                cardapioItem.PossuiPreparo = cardapio.PossuiPreparo;
            return Results.NoContent();

            }

            // DELETE api/<CardapioItemControlleer>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {

            }
        
    }

}
