using Models.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        ////https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/aud.json
        ///
        /// <summary>
        /// Get Australian Currency Exchange Data from CDN 
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetCurrencyExchangeData()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://cdn.jsdelivr.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method
                    HttpResponseMessage response = await client.GetAsync("gh/fawazahmed0/currency-api@1/latest/currencies/aud.json");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new HttpRequestException("Bad Request");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
