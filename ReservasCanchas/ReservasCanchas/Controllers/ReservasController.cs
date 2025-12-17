using Microsoft.AspNetCore.Mvc;
using ReservasCanchas.Data;
using ReservasCanchas.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace ReservasCanchas.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===============================
        // FORMULARIO PARA RESERVAR (GET)
        // ===============================
        public IActionResult Crear(int canchaId)
        {
            // 🔒 BLOQUEAR SI NO ESTÁ LOGUEADO
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var reserva = new Reserva
            {
                CanchaId = canchaId,
                Fecha = DateTime.Now,
                HoraInicio = TimeSpan.Zero,
                HoraFin = TimeSpan.Zero

            };

            return View(reserva);
        }

        // ===============================
        // GUARDAR RESERVA (POST)
        // ===============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Reserva reserva)
        {
            // 🔒 VERIFICAR LOGIN
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            reserva.UsuarioId = usuarioId.Value;

            // ❌ NO permitir fechas pasadas
            if (reserva.Fecha.Date < DateTime.Today)
            {
                ModelState.AddModelError("Fecha", "No puedes reservar una fecha pasada.");
            }

            // ❌ VALIDAR QUE NO EXISTA OTRA RESERVA IGUAL
            bool existeReserva = _context.Reservas.Any(r =>
                r.CanchaId == reserva.CanchaId &&
                r.Fecha.Date == reserva.Fecha.Date &&
                r.HoraInicio < reserva.HoraFin &&
                r.HoraFin > reserva.HoraInicio
            );

            if (existeReserva)
            {
                ModelState.AddModelError("", "La cancha ya está reservada en ese horario.");
            }


            if (!ModelState.IsValid)
            {
                return View(reserva);
            }
            


            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return RedirectToAction("MisReservas");
        }

        // ===============================
        // VER MIS RESERVAS
        // ===============================
        public IActionResult MisReservas()
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var reservas = _context.Reservas
                .Where(r => r.UsuarioId == usuarioId)
                .ToList();

            return View(reservas);
        }

        // ===============================
        // CANCELAR RESERVA
        // ===============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancelar(int id)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var reserva = _context.Reservas
                .FirstOrDefault(r => r.Id == id && r.UsuarioId == usuarioId);

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();

            return RedirectToAction("MisReservas");
        }

        public IActionResult Index()
        {
            return RedirectToAction("MisReservas");
        }
    }
}
