using Comanda.Api.DTOs;
using Comanda.Api.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comanda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public ComandaDbContext _context { get; set; }
        public UsuarioController(ComandaDbContext context)
        {
            _context = context;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IResult GetUsuario()
        {
            var usuarios = _context.Usuarios.ToList();
            return  Results.Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(us => us.Id == id);
            if (usuario == null)
            {
                return Results.NotFound("Usuario não encontrado!");
            }
            return Results.Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IResult Post([FromBody] UsuarioCreateResquest usuarioCreate)
        {
            if (usuarioCreate.Senha.Length < 6)
            {
                return Results.BadRequest("A senha deve ter no mínimo 6 caracteres.");

            }
            if (usuarioCreate.Nome.Length < 3)
            {
                return Results.BadRequest("O nome deve ter no mínimo 3 caratecteres.");
            }
            if(usuarioCreate.Email.Length < 3||!usuarioCreate.Email.Contains("@"))
                {
                return Results.BadRequest("O email deve ser valido.");
            }
            var usuario = new Usuario
            {
               
                Nome = usuarioCreate.Nome,
                Email = usuarioCreate.Email,
                Senha = usuarioCreate.Senha,
            };
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Results.Created($"/api/usuario/{usuario.Id}",usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] UsuarioUpdateResquest usuarioUpdate)
        {
            var usuario = _context.Usuarios.FirstOrDefault(us => us.Id == id);
            if (usuario is null)
                return Results.NotFound($"Usuario do {id} não encontrado.");
            usuario.Email = usuarioUpdate.Email;
          usuario.Nome = usuarioUpdate.Nome;
            usuario.Senha = usuarioUpdate.Senha;
            _context.SaveChanges();
            return Results.NoContent();
            
         }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario is null)
                return Results.NotFound($"Usuario com o id {id} não encontrado!");
             _context.Usuarios.Remove(usuario);
            var removido= _context.SaveChanges();
            if (removido > 0)
            {
                return Results.NoContent();
            }
            return Results.StatusCode(500);
        }
    }
}
