using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_ecommerce_deportivo_net.Integrations
{
    public class WeatherAPIIntegration
    {
        private readonly ILogger<WeatherAPIIntegration> _logger;

        private const string API_URL = "https://weatherapi-com.p.rapidapi.com/current.json";  // para el realtime

        // private const string API_URL = "https://weatherapi-com.p.rapidapi.com/forecast.json";  // para el forecast
        // private const string API_URL = "https://weatherapi-com.p.rapidapi.com/ip.json";  // para el IP Lookup
        // private const string API_URL = "https://weatherapi-com.p.rapidapi.com/timezone.json";  // para el Time Zone
        // private const string API_URL = "https://weatherapi-com.p.rapidapi.com/astronomy.json";  // para el Astronomy

        private const string API_KEY = "0f60cfd355msh859001a93668e79p1ca0e3jsn94c365a6deee";
        private const string API_HEADER_KEY = "X-RapidAPI-Key";

        private readonly HttpClient httpClient;
    }
}