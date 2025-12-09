using Comanda.Api.DTOs;
using Comanda.Api.Migrations;
using Comanda.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comanda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioItemController : ControllerBase
    {
     public ComandaDbContext _context { get; set; }
        public CardapioItemController(ComandaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public  IResult GetCardapio ()
        {
            var cardapios = _context.CardapioItens.Include(c => c.cardapioId).ToList();
            return Results.Ok(cardapios);
        }
            // GET api/<CardapioItemControlleer>/5
            [HttpGet("{id}")]
            public IResult Get(int id)
            {
                var cardapio  = _context.CardapioItens
                .Include(ci=>ci.CategoriaCardapioId)
                .FirstOrDefault(c => c.Id == id);
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
                if (cardapio.Imagem!=null)
            {
                if (!Uri.IsWellFormedUriString(cardapio.Imagem, UriKind.Absolute))
                {
                    return Results.BadRequest("A imagem deve ser uma URL válida.");
                }
            }
                if(cardapio.Tipo==null)
            {
                return Results.BadRequest("Não pode estar vazio. ");
            }

            //validacao de uma categoria se for prenchido
            if (cardapio.CategoriaCardapioId.HasValue)
            {
                var categoria= _context.categoriaCardapios
                    .FirstOrDefault(c => c.Id == cardapio.CategoriaCardapioId);
                if (categoria is null)
                {
                    return Results.BadRequest($"Categoria com ID {cardapio.CategoriaCardapioId} não existe.");
                }
            }
            var cardapioitem = new CardapioItem
            {
               
                Titulo = cardapio.Titulo,
                Descricao = cardapio.Descricao,
                Preco = cardapio.Preco,
                PossuiPreparo =cardapio.PossuiPreparo,
                Imagem = cardapio.Imagem,
                Tipo = cardapio.Tipo,
                CategoriaCardapioId = cardapio.CategoriaCardapioId
            };
            _context.CardapioItens.Add(cardapioitem);
            _context.SaveChanges();
            return Results.Created($"/api/cardapioItem/{cardapioitem.Id}", cardapio);
            }
        
        

            // PUT api/<CardapioItemControlleer>/5
            [HttpPut("{id}")]
            public IResult Put(int id, [FromBody] CardapioItemupdateResquest cardapio)
            {
            var cardapioItem = _context.CardapioItens.FirstOrDefault(c => c.Id == id);
            if (cardapioItem is null)
                return Results.NotFound($"Cardapio do {id} não encontrado");
            if (cardapio.CategoriaCardapioId.HasValue){
                var categoria = _context.categoriaCardapios
                    .FirstOrDefault(c => c.Id == cardapio.CategoriaCardapioId);
                if (categoria is null)
                {
                    return Results.BadRequest($"Categoria de cardapio invalida.");
                }
            }
                cardapioItem.Titulo = cardapio.Titulo;
                cardapioItem.Descricao = cardapio.Descricao;
                cardapioItem.Preco = cardapio.Preco;
                cardapioItem.PossuiPreparo = cardapio.PossuiPreparo;
                cardapioItem.Imagem = cardapio.Imagem;
                cardapioItem.Tipo = cardapio.Tipo;
            cardapioItem.CategoriaCardapioId = cardapio.CategoriaCardapioId;
            _context.SaveChanges();
            return Results.NoContent();

            }

            // DELETE api/<CardapioItemControlleer>/5
            [HttpDelete("{id}")]
            public IResult Delete(int id)
            {
                    var cardapioItem = _context.CardapioItens.FirstOrDefault(c =>c.Id == id);
                if (cardapioItem is null)
                    return Results.NotFound($"Cardapio {id} não encontrado!");
                    _context.Remove(cardapioItem);
                var removido = _context.SaveChanges() > 0;
                if (removido)
                    return Results.NoContent();

                return Results.StatusCode(500);
            }
        
    }

}
