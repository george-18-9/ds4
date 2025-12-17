using Microsoft.AspNetCore.Mvc;
using ReservasCanchas.Data;
using ReservasCanchas.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

public class UsuariosController : Controller
{
    private readonly ApplicationDbContext _context;

    public UsuariosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // REGISTRO
    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registro(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
        return RedirectToAction("Index", "Home");
    }

    // LOGIN
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string correo, string password)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.Correo == correo && u.Password == password);

        if (usuario == null)
        {
            ViewBag.Error = "Credenciales incorrectas";
            return View();
        }

        HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
        return RedirectToAction("Index", "Canchas");
    }

    // LOGOUT
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}

