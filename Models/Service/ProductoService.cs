using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using proyecto_ecommerce_deportivo_net.Data;

namespace proyecto_ecommerce_deportivo_net.Models.Service
{
    public class ProductoService
    {
        private readonly ILogger<ProductoService> _logger;
        private readonly ApplicationDbContext _context;

        public ProductoService(ILogger<ProductoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Producto> guardarProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<List<Producto>?> GetAll()
        {
            if (_context.Producto == null)
                return null;
            return await _context.Producto.ToListAsync();
        }

        public async Task<Producto?> Get(int? id)
        {
            if (id == null || _context.Producto == null)
            {
                return null;
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return null;
            }
            return producto;
        }

        public async Task<Producto?> FirstOrDefault(int? id)
        {
            var producto = await _context.Producto
                .FirstOrDefaultAsync(m => m.id == id);
            if (producto == null)
            {
                return null;
            }
            return producto;
        }

        public async Task Delete(int? id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto != null)
            {
                _context.Producto.Remove(producto);
            }
            await _context.SaveChangesAsync();
        }

        public bool ProductoExists(int id)
        {
            return (_context.Producto?.Any(e => e.id == id)).GetValueOrDefault();
        }

    }
}