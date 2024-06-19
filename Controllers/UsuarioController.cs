using Microsoft.AspNetCore.Mvc;
using mooexpress.Interfaces;
using mooexpress.Models;
using System.Collections.Generic;

namespace mooexpress.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), 200)]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioRepository.GetUsuarios();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(usuarios);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(400)]
        public IActionResult GetUsuario(int Id)
        {
            if (!_usuarioRepository.UsuarioExists(Id))
                return NotFound();

            var usuario = _usuarioRepository.GetUsuario(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Usuario))]
        [ProducesResponseType(400)]
        public IActionResult CreateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_usuarioRepository.CreateUsuario(usuario))
            {
                ModelState.AddModelError("", "Algo deu errado ao salvar o usuário");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetUsuario", new { Id = usuario.Id }, usuario);
        }
    }
}
