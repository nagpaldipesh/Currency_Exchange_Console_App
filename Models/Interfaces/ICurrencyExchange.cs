using MyLinkedList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ICurrencyExchange
    {
        Task ProcessCurrencyExchangeData();
        //void MergeSortAndPrintList(LinkedList lstAUDCurrencyExchangeRates);
        //void ExportResultIntoCSV(LinkedList lstAUDCurrencyExchangeRates);
        //string GetCurrentFolderName();
    }
}
