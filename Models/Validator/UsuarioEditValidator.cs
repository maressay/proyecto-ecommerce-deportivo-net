using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using proyecto_ecommerce_deportivo_net.Models.DTO;
using proyecto_ecommerce_deportivo_net.Models.DTO.Models.DTO;

namespace proyecto_ecommerce_deportivo_net.Models.Validator
{
    public class UsuarioEditValidator : AbstractValidator<UsuarioEditDTO>
    {
        public UsuarioEditValidator()
        {
            RuleFor(usuario => usuario.Nombres)
           .NotEmpty().WithMessage("El campo de Nombre es obligatorio");

           RuleFor(usuario => usuario.Apellidos)
            .NotEmpty().WithMessage("El campo de Apellidos obligatorio");

            RuleFor(usuario => usuario.Dni)
            .NotEmpty().WithMessage("El campo de Dni es obligatorio");
        }
    }
}