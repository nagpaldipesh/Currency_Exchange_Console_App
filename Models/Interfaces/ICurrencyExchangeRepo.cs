﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ICurrencyExchangeService
    {
        Task<string> GetCurrencyExchangeData();
    }
}
