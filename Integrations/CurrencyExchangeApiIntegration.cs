using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace proyecto_ecommerce_deportivo_net.Integrations
{
    public class CurrencyExchangeApiIntegration
    {
        private readonly ILogger<CurrencyExchangeApiIntegration> _logger;
        private const string API_URL = "https://currency-exchange.p.rapidapi.com/exchange";
        private const string API_KEY = "0f60cfd355msh859001a93668e79p1ca0e3jsn94c365a6deee";
        private const string API_HEADER_KEY = "X-RapidAPI-Key";

        private readonly HttpClient httpClient;

        public CurrencyExchangeApiIntegration(ILogger<CurrencyExchangeApiIntegration> logger)
        {
            _logger = logger;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(API_HEADER_KEY, API_KEY);
        }

        public async Task<double> GetExchangeRate(string fromCurrency, string toCurrency)
        {
            string requestUrl = $"{API_URL}?from={fromCurrency}&to={toCurrency}";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    double exchangeRate = Convert.ToDouble(result);
                    return exchangeRate;
                }
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error al llamar a la API: {ex.Message}");
            }
            return 0;
        }

       
    }
}