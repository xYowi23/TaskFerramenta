using Microsoft.AspNetCore.Mvc;
using Taskino_Ferramenta.Models;
using Taskino_Ferramenta.Services;

namespace Taskino_Ferramenta.Controllers
{
    [ApiController]
    [Route("api/reparti")]
    public class RepartoController : Controller
    {
        private readonly RepartoService _service;
        public RepartoController (RepartoService service)
        {
            _service = service;
        }

        [HttpGet("{varCodice}")]
        public ActionResult<RepartoDTO> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();
            RepartoDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);
            return NotFound();
        
        }
    }
}
