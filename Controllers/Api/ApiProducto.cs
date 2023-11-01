using Microsoft.AspNetCore.Mvc;
using proyecto_ecommerce_deportivo_net.Models;
using proyecto_ecommerce_deportivo_net.Models.Service;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/productos")]
public class ApiProducto : ControllerBase
{
    private readonly ProductoService _productoService;

    public ApiProducto(ProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int? page)
    {
        var productos = await _productoService.GetAll(page);
        if (productos == null)
        {
            return NotFound();
        }

        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var producto = await _productoService.Get(id);
        if (producto == null)
        {
            return NotFound();
        }

        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Producto producto)
    {
        var createdProducto = await _productoService.CreateOrUpdate(producto);
        return CreatedAtAction(nameof(Get), new { id = createdProducto.id }, createdProducto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
    {
        if (id != producto.id)
        {
            return BadRequest();
        }

        var existingProducto = await _productoService.Get(id);
        if (existingProducto == null)
        {
            return NotFound();
        }

        // Actualiza las propiedades del producto existente
        existingProducto.Nombre = producto.Nombre;
        existingProducto.Descripcion = producto.Descripcion;
        existingProducto.Imagen = producto.Imagen;
        existingProducto.Precio = producto.Precio;
        existingProducto.Stock = producto.Stock;
        existingProducto.fechaActualizacion = DateTime.UtcNow;  // Usa DateTime.UtcNow para la fecha

        // Llama al servicio para crear o actualizar el producto
        var updatedProducto = await _productoService.CreateOrUpdate(existingProducto);

        return Ok(updatedProducto);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingProducto = await _productoService.Get(id);
        if (existingProducto == null)
        {
            return NotFound();
        }

        await _productoService.Delete(id);
        return NoContent();
    }
}
