using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using proyecto_ecommerce_deportivo_net.Models;
using proyecto_ecommerce_deportivo_net.Data;
using proyecto_ecommerce_deportivo_net.Models.Entity;
using proyecto_ecommerce_deportivo_net.Models.Service;

namespace proyecto_ecommerce_deportivo_net.Controllers.UI
{
    public class ContactoController : Controller
    {
        private readonly ContactanosService _contactanosService;

        private readonly IMyEmailSender _emailSender;

        public ContactoController(ContactanosService contactanosService, IMyEmailSender emailSender)
        {
            _contactanosService = contactanosService;

            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contacto objContacto)
        {
            if (!ModelState.IsValid)
            {
                // Manejar errores de validación, si es necesario
                return BadRequest(ModelState);
            }

            await _contactanosService.CreateOrUpdate(objContacto);

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

            //return Ok(objContacto);
            return View("~/Views/Contacto/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}