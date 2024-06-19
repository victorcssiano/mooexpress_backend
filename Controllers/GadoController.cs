using Microsoft.AspNetCore.Mvc;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[Controller]")]
    [ApiController]
    public class GadoController : Controller
    {
        private readonly IGadoRepository _gadoRepository;
        public GadoController(IGadoRepository gadoRepository)
        {
            _gadoRepository = gadoRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Gado>), 200)]
        public IActionResult GetGados()
        {
            var gados = _gadoRepository.GetGados();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(gados);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Gado))]
        [ProducesResponseType(400)]
        public IActionResult GetGado(int Id)
        {
            if (!_gadoRepository.GadoExists(Id))
                return NotFound();

            var gado = _gadoRepository.GetGado(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(gado);
        }

        //[HttpPost("{Id}")]
    }
}
