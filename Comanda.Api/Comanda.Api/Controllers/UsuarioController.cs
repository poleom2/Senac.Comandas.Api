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
        static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario
            {
                Id = 1,
                Nome = "Miguel",
                Email = "admin@admin.com",
                Senha = "admin"
            },
            new Usuario
            {
                Id = 2,
                Nome = "Nehemias",
                 Email = "nehemias@gmail.com",
                 Senha= "admin"
            }

        };
        // GET: api/<UsuarioController>
        [HttpGet]
        public IResult GetUsuario()
        {
            return  Results.Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var usuario = usuarios.FirstOrDefault(us => us.Id == id);
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
                Id = usuarios.Count + 1,
                Nome = usuarioCreate.Nome,
                Email = usuarioCreate.Email,
                Senha = usuarioCreate.Senha,
            };
            usuarios.Add(usuario);
            return Results.Created($"/api/usuario/{usuario.Id}",usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] UsuarioUpdateResquest usuarioUpdate)
        {
            var usuario = usuarios.FirstOrDefault(us => us.Id == id);
            if (usuario is null)
                return Results.NotFound($"Usuario do {id} não encontrado.");
            usuario.Email = usuarioUpdate.Email;
          usuario.Nome = usuarioUpdate.Nome;
            usuario.Senha = usuarioUpdate.Senha;
                return Results.NoContent();
            
         }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario is null)
                return Results.NotFound($"Usuario com o id {id} não encontrado!");
             var usuarioremovido  = usuarios.Remove(usuario);
            if (usuarioremovido)
                return Results.NoContent();
            return Results.StatusCode(500);
        }
    }
}
