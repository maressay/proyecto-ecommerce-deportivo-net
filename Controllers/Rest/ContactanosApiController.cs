using Microsoft.AspNetCore.Mvc;
using proyecto_ecommerce_deportivo_net.Models;
using proyecto_ecommerce_deportivo_net.Models.Entity;
using proyecto_ecommerce_deportivo_net.Models.Service;
using System;
using System.Threading.Tasks;

namespace proyecto_ecommerce_deportivo_net.Controllers.Rest
{
    [ApiController]
    [Route("api/contactos")]
    public class ContactanosApiController : ControllerBase
    {
        private readonly ContactanosService _contactanosService;

        public ContactanosApiController(ContactanosService contactanosService)
        {
            _contactanosService = contactanosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? page)
        {
            var contacto = await _contactanosService.GetAll(page);
            if (contacto == null)
            {
                return NotFound();
            }

            return Ok(contacto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contacto = await _contactanosService.Get(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return Ok(contacto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contacto contacto)
        {
            var createdContacto = await _contactanosService.CreateOrUpdate(contacto);
            return CreatedAtAction(nameof(Get), new { id = createdContacto.Id }, createdContacto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return BadRequest();
            }

            var existingContacto = await _contactanosService.Get(id);
            if (existingContacto == null)
            {
                return NotFound();
            }

            // Actualiza las propiedades del contacto existente
            existingContacto.Nombre = contacto.Nombre;
            existingContacto.Email  = contacto.Email;
            existingContacto.Phone  = contacto.Phone;
            existingContacto.Asunto  = contacto.Asunto;
            existingContacto.Mensaje  = contacto.Mensaje;
       

            // Llama al servicio para crear o actualizar el contacto
            var updatedContacto = await _contactanosService.CreateOrUpdate(existingContacto);

            return Ok(updatedContacto);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingContacto = await _contactanosService.Get(id);
            if (existingContacto == null)
            {
                return NotFound();
            }

            await _contactanosService.Delete(id);
            return NoContent();
        }
    }
}