using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace TP07.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Juego juego = new Juego();
        List<Usuario> listaJugadores = new List<Usuario>();
        if (objeto.StringToObject<Juego>(HttpContext.Session.GetString("JuegoActual")) != null)
        {
            juego = objeto.StringToObject<Juego>(HttpContext.Session.GetString("JuegoActual"));
        }
        string listaString = HttpContext.Session.GetString("ListaJugadores");
        if (!string.IsNullOrEmpty(listaString))
        {
            listaJugadores = objeto.StringToObject<List<Usuario>>(listaString);
        }
        ViewBag.Jugadores = listaJugadores;
        return View();
    }
    [HttpPost]
    public IActionResult Comenzar(string username, int dificultad)
    {
        Juego juego = new Juego();
        juego.LlenarListaPalabras();
        juego.InicializarJuego(username, dificultad);
        HttpContext.Session.SetString("JuegoActual", objeto.ObjectToString(juego));
        ViewBag.Usuario = username;
        ViewBag.Palabra = juego.PalabraActual;
        return View("Juego");
    }
    public IActionResult FinJuego(int intentos)
    {
        Juego juego = objeto.StringToObject<Juego>(HttpContext.Session.GetString("JuegoActual"));
        juego.JugadorActual.CantidadIntentos = intentos;
        juego.FinJuego();
        List<Usuario> listaJugadores = new List<Usuario>();
        string listaString = HttpContext.Session.GetString("ListaJugadores");
        if (!string.IsNullOrEmpty(listaString))
        {
            listaJugadores = objeto.StringToObject<List<Usuario>>(listaString);
        }
        HttpContext.Session.SetString("ListaJugadores", objeto.ObjectToString(juego.DevolverListaUsuarios()));
        HttpContext.Session.Remove("JuegoActual");
        return RedirectToAction("Index");
    }
}
