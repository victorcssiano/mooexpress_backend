using Microsoft.AspNetCore.Mvc;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[Controller]")]
    [ApiController]
    public class AvaliacoesController : Controller
    {
        private readonly IAvaliacoesRepository _avaliacoesRepository;
        public AvaliacoesController(IAvaliacoesRepository avaliacoesRepository)
        {
            _avaliacoesRepository = avaliacoesRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Avaliacoes>), 200)]
        public IActionResult GetAvaliacoes()
        {
            var avaliacoes = _avaliacoesRepository.GetAvaliacoes();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(avaliacoes);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Avaliacoes))]
        [ProducesResponseType(400)]
        public IActionResult GetAvaliacoes(int Id)
        {
            if (!_avaliacoesRepository.AvaliacoesExists(Id))
                return NotFound();

            var avaliacoes = _avaliacoesRepository.GetAvaliacoes(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(avaliacoes);
        }

        //[HttpPost("{Id}")]
    }
}

