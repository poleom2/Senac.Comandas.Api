using Comanda.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
            public void Post([FromBody] string value)
            {
            }

            // PUT api/<CardapioItemControlleer>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<CardapioItemControlleer>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {

            }
        
    }

}
