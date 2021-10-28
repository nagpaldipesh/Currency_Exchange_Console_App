using System;

namespace Models
{
    public class AUDCurrencyExchange
    {
        private string _countryCode;
        private double _currencyExchangeValue;

        public string CountryCode
        {
            get
            {
                return _countryCode;
            }
            set
            {
                _countryCode = value;
            }
        }

        public double CurrencyExchangeValue
        {
            get
            {
                return _currencyExchangeValue;
            }
            set
            {
                _currencyExchangeValue = value;
            }
        }

    }
}
