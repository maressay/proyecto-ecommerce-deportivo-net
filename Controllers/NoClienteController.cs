using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace proyecto_ecommerce_deportivo_net.Controllers
{
    [Route("[controller]")]
    public class NoClienteController : Controller
    {
        private readonly ILogger<NoClienteController> _logger;

        public NoClienteController(ILogger<NoClienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}