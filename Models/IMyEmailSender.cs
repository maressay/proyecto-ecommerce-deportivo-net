using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_ecommerce_deportivo_net.Models
{
    public interface IMyEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}