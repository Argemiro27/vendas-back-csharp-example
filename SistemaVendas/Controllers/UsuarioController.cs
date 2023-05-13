using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> AllUsers() 
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.AllUsers();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> GetById(int id)
        {
            UsuarioModel usuarios = await _usuarioRepository.GetById(id);
            return Ok(usuarios);
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<List<UsuarioModel>>> GetByEmail(string email)
        {
            UsuarioModel usuarios = await _usuarioRepository.GetByEmail(email);
            return Ok(usuarios);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepository.Create(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("id")]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.id = id;
            UsuarioModel usuario = await _usuarioRepository.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool deleted = await _usuarioRepository.Delete(id);
            return Ok(deleted);
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UsuarioModel model)
        {
            var usuario = await _usuarioRepository.GetByEmail(model.email);

            if (usuario == null)
                return NotFound(new { message = "Usuário não encontrado" });

            if (!BCrypt.Net.BCrypt.Verify(model.password, usuario.password))
                return BadRequest(new { message = "Senha incorreta" });

            return Ok(new { message = "Login realizado com sucesso!" });
        }

    }
}
