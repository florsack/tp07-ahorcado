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
        Juego juego = objeto.StringToObject<Juego>(HttpContext.Session.GetString("JuegoActual"));
        ViewBag.Jugadores = juego.DevolverListaUsuarios();
        return View();
    }
    public IActionResult Comenzar(string username, int dificultad)
    {
        Juego juego = new Juego();
        juego.LlenarListaPalabras();
        juego.InicializarJuego(username, dificultad);
        HttpContext.Session.SetString("JuegoActual", objeto.ObjectToString(juego));
        ViewBag.Usuario = username;
        ViewBag.Palabra = juego.PalabraActual;
        return View();
    }
}
