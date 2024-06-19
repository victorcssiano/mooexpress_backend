using Microsoft.AspNetCore.Mvc;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[Controller]")]
    [ApiController]
    public class Endereco_entregaController : Controller
    {
        private readonly IEndereco_entregaRepository _endereco_entregaRepository;
        public Endereco_entregaController(IEndereco_entregaRepository endereco_entregaRepository)
        {
            _endereco_entregaRepository = endereco_entregaRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Endereco_entrega>), 200)]
        public IActionResult GetEnderecos()
        {
            var endereco_entregas = _endereco_entregaRepository.GetEnderecos();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(endereco_entregas);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Endereco_entrega))]
        [ProducesResponseType(400)]
        public IActionResult GetEndereco(int Id)
        {
            if (!_endereco_entregaRepository.EnderecoExists(Id))
                return NotFound();

            var endereco = _endereco_entregaRepository.GetEndereco(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(endereco);
        }

        //[HttpPost("{Id}")]
    }
}
