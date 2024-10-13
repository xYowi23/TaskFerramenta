using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Taskino_Ferramenta.Models;
using Taskino_Ferramenta.Services;

namespace Taskino_Ferramenta.Controllers
{
    [ApiController]
    [Route("api/reparti")]
    public class RepartoController : Controller
    {
        private readonly RepartoService _service;
        public RepartoController(RepartoService service)
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

        [HttpGet("tutti")]
        public ActionResult<List<RepartoDTO>> ElencoReparti()
        {
            var reparti = _service.Lista();

            if (reparti is not null)
                return Ok(reparti);

            return NotFound();
        }

        [HttpPost]
        public IActionResult InserisceReparto(RepartoDTO rDTO)
        {
            if ((rDTO.Nom.IsNullOrEmpty()) || (rDTO.Fil.IsNullOrEmpty()))
                return BadRequest();


            if (_service.Inserisci(rDTO))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{varCodice}")]
        public IActionResult EliminaReparto(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            if (_service.Elimina(varCodice))
                return Ok();

            return NotFound();
        }

        [HttpPut("{varCodice}")]
        public IActionResult AggiornaReparto(string varCodice, string nom, string fil)
        {

            if ( string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(fil))
            {
                return BadRequest("Dati non validi.");
            }

            var repartoDTO = new RepartoDTO
            {
                Cod = varCodice,
                Nom = nom,
                Fil = fil
            };

            bool risultato = _service.Aggiorna(repartoDTO);

            if (risultato)
            {
                return NoContent();
            }
            return NotFound($"Reparto con codice {varCodice} non trovato.");

        }

    }
}
