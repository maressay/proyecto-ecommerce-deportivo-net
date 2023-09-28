using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using proyecto_ecommerce_deportivo_net.Models;
using Microsoft.Extensions.Logging;
using proyecto_ecommerce_deportivo_net.Data;
using proyecto_ecommerce_deportivo_net.Models.Entity;

namespace proyecto_ecommerce_deportivo_net.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<HomeController> logger,
        ApplicationDbContext context)
    {
        _logger = logger;

        /* lineas agregadas */
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contacto()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Contacto objContacto)
    {
        _context.Add(objContacto);
        _context.SaveChanges();

        ViewData["Message"] = "Estimado " + objContacto.Nombre + ", te estaremos contactando pronto";
        return View("~/Views/Home/Contacto.cshtml");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
