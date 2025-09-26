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
        [HttpGet]
        public IEnumerable<CardapioItem> Get()
        {
            return new CardapioItem[] {
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

                },
            };
        }
            // GET api/<CardapioItemControlleer>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
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
