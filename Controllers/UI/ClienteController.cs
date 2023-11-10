using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_ecommerce_deportivo_net.Data;
using proyecto_ecommerce_deportivo_net.Models;
using proyecto_ecommerce_deportivo_net.Models.DTO;
using proyecto_ecommerce_deportivo_net.Models.Validator;

namespace proyecto_ecommerce_deportivo_net.Controllers.UI
{
    public class ClienteController : Controller
    {private readonly ILogger<ClienteController> _logger;

        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public ClienteController(ILogger<ClienteController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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

        [HttpGet]
        public async Task<ActionResult> EditarUsuario(string? id)
        {

            ApplicationUser? usuarioEditar = await _context.Users.FindAsync(id);

            if (usuarioEditar == null)
            {
                Console.Write("No se encontro");
                return NotFound();
            }

            UsuarioEditDTO usuarioEditarDTO = new UsuarioEditDTO();
            usuarioEditarDTO.Id = usuarioEditar.Id;
            usuarioEditarDTO.Nombres = usuarioEditar.Nombres;
            usuarioEditarDTO.Apellidos = usuarioEditar.Apellidos;
            usuarioEditarDTO.Dni = usuarioEditar.Dni;
            return View("EditarUsuario", usuarioEditarDTO);

        }

        [HttpPost]
        public async Task<IActionResult> GuardarUsuarioEditado(UsuarioEditDTO usuarioEditDTO)
        {

            UsuarioEditValidator validator = new UsuarioEditValidator();
            ValidationResult result = validator.Validate(usuarioEditDTO);

            if (result.IsValid)
            {
                ApplicationUser? user = await _context.Users.FindAsync(usuarioEditDTO.Id);
                user.Nombres = usuarioEditDTO.Nombres;
                user.Apellidos = usuarioEditDTO.Apellidos;
                user.Dni = usuarioEditDTO.Dni;

                TempData["MessageActualizandoUsuario"] = "Se Actualizaron exitosamente los datos.";
                _context.Users.Update(user);
                _context.SaveChanges();

                return RedirectToAction("EditarUsuario", new { id = usuarioEditDTO.Id });
            }

            foreach (var failure in result.Errors)
            {
                ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }
            return View("EditarUsuario", usuarioEditDTO);

        }
    }
}