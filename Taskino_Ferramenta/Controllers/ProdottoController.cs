using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Taskino_Ferramenta.Models;
using Taskino_Ferramenta.Services;

namespace Taskino_Ferramenta.Controllers
{
    [ApiController]
    [Route("api/prodotti")]
    public class ProdottoController : Controller
    {
        private readonly ProdottoService _service;

        public ProdottoController(ProdottoService service)
        {
            _service = service;
        }

        [HttpGet("{varCodice}")]
        public ActionResult<ProdottoDTO?> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            ProdottoDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }
        [HttpGet("tutti")]
        public ActionResult<List<ProdottoDTO>> ElencoProdotti()
        {
            var prodotti = _service.Lista();
            if (prodotti is not null)
                return Ok(prodotti);
            return NotFound();
        
        
        }
        [HttpPost]
        public IActionResult InserisceReparto(ProdottoDTO pDTO)
        {
            if ((pDTO.Nom.IsNullOrEmpty()) || (pDTO.Desc.IsNullOrEmpty()))
                return BadRequest();


            if (_service.Inserisci(pDTO))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{varCodice}")]
        public IActionResult EliminaProdotto(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            if (_service.Elimina(varCodice))
                return Ok();

            return NotFound();
        }

        [HttpPut("{varCodice}")]
        public IActionResult AggiornaProdotto(string varCodice, string nom, string des,decimal prez, int quant,int reprif )
        {

            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(des))
            {
                return BadRequest("Dati non validi.");
            }

            var prodottoDTO = new ProdottoDTO
            {
                CodBar = varCodice,
                Nom = nom,
                 Desc= des,
                 Prez= prez,
                 Quant= quant,
                 RepRif=reprif

            };

            bool risultato = _service.Aggiorna(prodottoDTO);

            if (risultato)
            {
                return NoContent();
            }
            return NotFound($"prodotto con codice {varCodice} non trovato.");

        }





    }
}
