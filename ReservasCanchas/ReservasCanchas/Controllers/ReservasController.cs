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
                HoraInicio = "",
                HoraFin = ""
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

            if (!ModelState.IsValid)
            {
                return View(reserva);
            }
            // FORMATEAR HORAS A AM / PM
            var inicio = DateTime.Parse(reserva.HoraInicio);
            var fin = DateTime.Parse(reserva.HoraFin);

            reserva.HoraInicio = inicio.ToString("hh:mm tt");
            reserva.HoraFin = fin.ToString("hh:mm tt");


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
