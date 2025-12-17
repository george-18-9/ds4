using Microsoft.AspNetCore.Mvc;
using ReservasCanchas.Data;
using ReservasCanchas.Models;

namespace ReservasCanchas.Controllers
{
    public class CanchasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CanchasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var canchas = _context.Canchas.ToList();
            return View(canchas);
        }
    }
}
