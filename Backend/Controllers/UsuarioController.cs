using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using Services;

namespace OnFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _context;

        public UsuarioController(Context context)
        {
            _context = context;
        }

       [HttpPost]
        [Route("Login")]
        public ActionResult<dynamic> Login([FromBody]Credencial credencial)
        {
            // Localizar usuário no banco de dados.
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Login == credencial.Login);

            // Verificar se o usuário existe na base e comparar as senhas.
            if (usuario == null || !SenhaService.CompararHash(credencial.Senha, usuario.Senha)) {
              return NotFound(new { message = "Usuário ou senha inválidos"});
            }

            // Gerar o Token
            var token = TokenService.GerarToken(usuario);

            return new {
              usuario = usuario,
              token = token
            };
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody]Credencial credencial)
        {

            string senha = credencial.Senha;
            string hash = SenhaService.GerarHash(senha);

            Usuario usuario = new Usuario();
            usuario.Id = id;
            usuario.Login = credencial.Login;
            usuario.Papel = credencial.Papel;
            usuario.Senha = hash;

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody]Credencial credencial )
        {
            string senha = credencial.Senha;
            string hash = SenhaService.GerarHash(senha);
                      
            Usuario usuario = new Usuario();
            usuario.Login = credencial.Login;
            usuario.Papel = credencial.Papel;
            usuario.Senha = hash;


            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
