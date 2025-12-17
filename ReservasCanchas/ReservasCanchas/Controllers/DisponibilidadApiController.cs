using Microsoft.AspNetCore.Mvc;
using ReservasCanchas.Data;

namespace ReservasCanchas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DisponibilidadApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{canchaId}/{fecha}")]
        public IActionResult GetDisponibilidad(int canchaId, DateTime fecha)
        {
            var reservas = _context.Reservas
                .Where(r => r.CanchaId == canchaId && r.Fecha == fecha)
                .ToList();

            return Ok(reservas);
        }
    }
}

