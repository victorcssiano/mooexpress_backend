using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[Controller]")]
    [ApiController]
    public class AnuncioController : Controller
    {
        private readonly IAnuncioRepository _anuncioRepository;
        public AnuncioController(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(typeof(IEnumerable<Anuncio>), 200)]
        public IActionResult GetAnuncios()
        {
            var anuncios = _anuncioRepository.GetAnuncios();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(anuncios);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Anuncio))]
        [ProducesResponseType(400)]
        public IActionResult GetAnuncio(int Id)
        {
            if (!_anuncioRepository.AnuncioExists(Id))
                return NotFound();

            var anuncio = _anuncioRepository.GetAnuncio(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(anuncio);
        }

        //[HttpPost("{Id}")]
    }
}
