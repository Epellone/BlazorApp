using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcolatriceController : Controller
    {
        private static List<Operazioni> listaOperazioni = new List<Operazioni>();

        private readonly ILogger<CalcolatriceController> _logger;

        public CalcolatriceController(ILogger<CalcolatriceController> logger)
        {
            _logger = logger;
        }

        [HttpGet("cronologia")]
        public IEnumerable<Operazioni> GetAll()
        {
            return listaOperazioni;
        }

        [HttpPost("aggiungi")]
        public IActionResult AddOperazione([FromBody] Operazioni operazione)
        {
            if (operazione == null)
            {
                return BadRequest("Operazione non valida");
            }
            listaOperazioni.Add(operazione);
            return Ok(listaOperazioni);
        }

        [HttpPut("modifica")]
        public IActionResult Update(int id, [FromBody] Operazioni updatedOperazione)
        {
            if (updatedOperazione == null)
            {
                return BadRequest("Operazione non valida");
            }

            var operazione = listaOperazioni.FirstOrDefault(o => o.ID == id);
            if (operazione == null)
            {
                return NotFound(); 
            }
            operazione.valore1 = updatedOperazione.valore1;
            operazione.valore2 = updatedOperazione.valore2;
            operazione.segno = updatedOperazione.segno;
            operazione.risultato = CalcolaRisultato(operazione);

            return Ok(listaOperazioni); 
        }

        private double? CalcolaRisultato(Operazioni risultatomodificato)
        {
            if (risultatomodificato.segno == "+")
            {
                return risultatomodificato.valore1 + risultatomodificato.valore2;
            }
            else if (risultatomodificato.segno == "-")
            {
                return risultatomodificato.valore1 - risultatomodificato.valore2;
            }
            else if (risultatomodificato.segno == "*")
            {
                return risultatomodificato.valore1 * risultatomodificato.valore2;
            }
            else if (risultatomodificato.segno == ":")
            {
                return risultatomodificato.valore1 / risultatomodificato.valore2;
            }
            return 0.0;
        }

    }
}
