using System;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraAPI.Data;
using CalculadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly CalculadoraContext _context;

        public CalculoController(CalculadoraContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Calculos.ToListAsync());
        }

        [HttpGet("sumas")]
        public async Task<IActionResult> GetSumas()
        {
            return Ok(await _context.Calculos
                .Where(c => c.Operacion == "Suma")
                .ToListAsync());
        }

        [HttpGet("restas")]
        public async Task<IActionResult> GetRestas()
        {
            return Ok(await _context.Calculos
                .Where(c => c.Operacion == "Resta")
                .ToListAsync());
        }

        [HttpGet("multiplicaciones")]
        public async Task<IActionResult> GetMultiplicaciones()
        {
            return Ok(await _context.Calculos
                .Where(c => c.Operacion == "Multiplicacion")
                .ToListAsync());
        }

        [HttpGet("divisiones")]
        public async Task<IActionResult> GetDivisiones()
        {
            return Ok(await _context.Calculos
                .Where(c => c.Operacion == "Division")
                .ToListAsync());
        }

        [HttpGet("fecha/{fecha}")]
        public async Task<IActionResult> GetPorFecha(DateTime fecha)
        {
            return Ok(await _context.Calculos
                .Where(c => c.Fecha.Date == fecha.Date)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Calculo calc)
        {
            await _context.Calculos.AddAsync(calc);
            await _context.SaveChangesAsync();
            return Ok(calc);
        }
    }
}