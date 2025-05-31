using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using proyecto_ecommerce_deportivo_net.Models;
using Microsoft.Extensions.Logging;
using proyecto_ecommerce_deportivo_net.Data;
using proyecto_ecommerce_deportivo_net.Models.Entity;
using proyecto_ecommerce_deportivo_net.Models.Service;
namespace proyecto_ecommerce_deportivo_net.Controllers.UI;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    private readonly ContactanosService _contactanosService;

    private readonly IMyEmailSender _emailSender;
    public HomeController(ILogger<HomeController> logger,
        ApplicationDbContext context, IMyEmailSender emailSender, ContactanosService contactanosService)
    {
        _logger = logger;

        /* lineas agregadas */
        _context = context;

        _emailSender = emailSender;

        //
        _contactanosService = contactanosService;
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
    public async Task<IActionResult> Create(Contacto objContacto)
    {
        _context.Add(objContacto);
        await _context.SaveChangesAsync();

        var message = $"Estimado(a) {objContacto.Nombre}, te estaremos contactando pronto";
        TempData["MessageCONTACTO"] = message;

        var message1 = $@"
            Estimado(a) {objContacto.Nombre},

            ¡Gracias por ponerte en contacto con nosotros!

            Hemos recibido tu solicitud y uno de nuestros representantes se pondrá en contacto contigo a la brevedad. 
            Valoramos tu interés y nos esforzamos por responder todas las consultas lo más rápido posible.

            Tu mensaje fue:
            {objContacto.Mensaje}

            Tu Número Telefónico fue: {objContacto.Phone}
            Tu Correo electronico fue: {objContacto.Email}

            Mientras tanto, te invitamos a explorar nuestro sitio web o nuestras redes sociales para obtener más información sobre nuestros productos y servicios.

            ¡Gracias por elegirnos!

            Saludos cordiales,

            [La Empresa Deportiva AthletiX]
        ";

        //await _emailSender.SendEmailAsync(objContacto.Email, "Gracias por contactarnos", message);
        await _emailSender.SendEmailAsync(objContacto.Email, "" + objContacto.Asunto, message1);

        // En lugar de return View(...), rediriges al GET de Contacto
        TempData["MessageConsola"] = "Gracias por contactarse con nosotros.";
    return RedirectToAction("Contacto");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
