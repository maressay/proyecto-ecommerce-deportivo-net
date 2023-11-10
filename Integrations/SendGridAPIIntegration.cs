using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_ecommerce_deportivo_net.Integrations
{
    public class SendGridAPIIntegration
    {
        private readonly ILogger<SendGridAPIIntegration> _logger;

        private const string API_URL = "https://rapidprod-sendgrid-v1.p.rapidapi.com/mail/send";  // para enviar emails
        private const string API_KEY = "0f60cfd355msh859001a93668e79p1ca0e3jsn94c365a6deee";
        private const string API_HEADER_KEY = "X-RapidAPI-Key";

        private readonly HttpClient httpClient;
    }
}