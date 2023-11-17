using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using proyecto_ecommerce_deportivo_net.Data;
using proyecto_ecommerce_deportivo_net.Models.Entity;
using X.PagedList;

namespace proyecto_ecommerce_deportivo_net.Models.Service
{
    public class ContactanosService
    {
        private readonly ILogger<ContactanosService> _logger;
        private readonly ApplicationDbContext _context;

        public ContactanosService(ILogger<ContactanosService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Contacto> CreateOrUpdate(Contacto contacto)
        {
            var p = _context.DataContactos.Find(contacto.Id);
            if (p != null)
            {
                _context.DataContactos.Update(contacto);
            }
            else
            {
                _context.DataContactos.Add(contacto);
            }

            await _context.SaveChangesAsync();
            return contacto;
        }

        public async Task<IPagedList> GetAll(int? page)
        {
            int pageNumber = (page ?? 1); // Si no se especifica la página, asume la página 1
            int pageSize = 100; // maximo 3 productos por pagina


            pageNumber = Math.Max(pageNumber, 1);// Con esto se asegura de que pageNumber nunca sea menor que 1

            return await _context.DataContactos.ToPagedListAsync(pageNumber, pageSize);
        }

        public List<Contacto>? GetAll()
        {
            if (_context.DataContactos == null)
                return null;
            return _context.DataContactos.ToList();
        }

        public async Task<List<Contacto>?> GetAllAsync()
        {
            if (_context.DataContactos == null)
                return null;
            return await _context.DataContactos.ToListAsync();
        }

        public async Task<Contacto?> Get(int? id)
        {
            if (id == null || _context.DataContactos == null)
            {
                return null;
            }

            var contacto = await _context.DataContactos.FindAsync(id);
            if (contacto == null)
            {
                return null;
            }
            return contacto;
        }

        public async Task<Contacto?> FirstOrDefault(int? id)
        {
            var contacto = await _context.DataContactos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contacto == null)
            {
                return null;
            }
            return contacto;
        }

        public async Task Delete(int id)
        {
            var contacto = await _context.DataContactos.FindAsync(id);
            if (contacto != null)
            {
                _context.DataContactos.Remove(contacto);
            }

            await _context.SaveChangesAsync();
        }

        public bool ContactosExists(int id)
        {
            return (_context.DataContactos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}