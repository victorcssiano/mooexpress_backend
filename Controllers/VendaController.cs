using Microsoft.AspNetCore.Mvc;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[Controller]")]
    [ApiController]
    public class VendaController : Controller
    {
        private readonly IVendaRepository _vendaRepository;
        public VendaController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Venda>), 200)]
        public IActionResult GetVendas()
        {
            var vendas = _vendaRepository.GetVendas();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(vendas);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Venda))]
        [ProducesResponseType(400)]
        public IActionResult GetVenda(int Id)
        {
            if (!_vendaRepository.VendaExists(Id))
                return NotFound();

            var venda = _vendaRepository.GetVenda(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(venda);
        }

        //[HttpPost("{Id}")]
    }
}
