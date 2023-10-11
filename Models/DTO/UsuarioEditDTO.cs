using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace proyecto_ecommerce_deportivo_net.Models.DTO.Models.DTO
{

    public class UsuarioEditDTO
    {
        public string? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Dni {get; set;}
    }

}