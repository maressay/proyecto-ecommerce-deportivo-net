using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using proyecto_ecommerce_deportivo_net.Data;
using proyecto_ecommerce_deportivo_net.Models;
using proyecto_ecommerce_deportivo_net.Models.Validator;
using X.PagedList;

namespace proyecto_ecommerce_deportivo_net.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _context;

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            ModelState.Clear();
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
        public IActionResult AgregarProducto()
        {
            return View("AgregarProducto");
        }


        [HttpPost]
        public IActionResult GuardarProducto(ProductoDTO productoDTO)
        {
            ProductoValidator validator = new ProductoValidator();
            ValidationResult result = validator.Validate(productoDTO);

            // Si se cumple con la validacion
            if (result.IsValid)
            {
                Producto producto = new();

                producto.Nombre = productoDTO.Nombre;
                producto.Descripcion = productoDTO.Descripcion;
                // producto.Imagen = productoDTO.Imagen; agregar logica para subir imagen y esas cosas ya sabes
                producto.Imagen = "Seria un link de onedrive, SI SUPIERA COMO SE HACE!!";
                producto.Precio = productoDTO.Precio;
                producto.Stock = productoDTO.Stock;
                producto.fechaCreacion = DateTime.Now.ToUniversalTime(); ;
                producto.fechaActualizacion = null;

                _context.Producto.Add(producto);
                _context.SaveChanges();

                return RedirectToAction("AgregarProducto");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            // Si hay campos que no cumplen con la validacion
            return View("AgregarProducto");
        }

        public ActionResult ListaDeProductos(int? page)
        {
            int pageNumber = (page ?? 1); // Si no se especifica la página, asume la página 1
            int pageSize = 2;
            IPagedList listaPaginada = _context.Producto.ToPagedList(pageNumber, pageSize);
            return View("ListaDeProductos", listaPaginada);
        }
    }



}