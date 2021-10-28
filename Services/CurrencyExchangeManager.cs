using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Models.Interfaces;
using MyLinkedList;

namespace Services
{
    public class CurrencyExchangeManager : ICurrencyExchangeManager
    {
        private readonly ICurrencyExchangeService _currencyExchangeRepo;
        public CurrencyExchangeManager(ICurrencyExchangeService currencyExchangeRepo)
        {
            _currencyExchangeRepo = currencyExchangeRepo;
        }

        #region Public Methods
        /// <summary>
        /// Get Currency Exhange Data from Repo
        /// </summary>
        /// <returns></returns>
        public async Task<LinkedList> GetCurrencyExchangeData()
        {
            string result = await _currencyExchangeRepo.GetCurrencyExchangeData();
            LinkedList currencyExchangeRates = ConvertJsonIntoLinkedList(result);
            return currencyExchangeRates;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Convert JSON String into Linked List
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private LinkedList ConvertJsonIntoLinkedList(String jsonResult)
        {
            JObject obj = JObject.Parse(jsonResult);
            // get JSON result objects into a list
            var results = obj["aud"].Children();
            LinkedList linkedList = new LinkedList();
            foreach (JToken result in results)
            {
                linkedList.Push(countryCode: ((JProperty)result).Name,
                   currencyExchangeValue: Convert.ToDouble(((JProperty)result).Value));
            }
            return linkedList;
        }

        #endregion
    }
}
