using CsvHelper;
using Models;
using Models.Interfaces;
using MyLinkedList;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CurrencyExchange : ICurrencyExchange
    {
        private static ICurrencyExchangeManager _currencyExchangeManager;
        public CurrencyExchange(ICurrencyExchangeManager currencyExchangeManager)
        {
            _currencyExchangeManager = currencyExchangeManager;
        }

        public async Task ProcessCurrencyExchangeData()
        {
            try
            {
                //Get CurrencyExchangeData
                LinkedList lstAUDCurrencyExchangeRates = await _currencyExchangeManager.GetCurrencyExchangeData();
                //Apply Merge Sort and Print List to Console After Merging
                MergeSortAndPrintList(lstAUDCurrencyExchangeRates);
                Console.WriteLine("Do you want to save the result into CSV File. If Yes, Please press 1.");
                int num = Convert.ToInt32(Console.ReadLine());
                //Exporting the CSV File if user presses 1
                if (num == 1)
                {
                    ExportResultIntoCSV(lstAUDCurrencyExchangeRates);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Apply Merge Sort
        /// Print the result to Console
        /// </summary>
        /// <param name="lstAUDCurrencyExchangeRates"></param>
        private static void MergeSortAndPrintList(LinkedList lstAUDCurrencyExchangeRates)
        {
            try
            {
                lstAUDCurrencyExchangeRates.Head = lstAUDCurrencyExchangeRates.MergeSort(lstAUDCurrencyExchangeRates.Head);
                Console.Write("\n Sorted Linked List is: \n");
                lstAUDCurrencyExchangeRates.PrintList(lstAUDCurrencyExchangeRates.Head);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Export the result into the CSV File
        /// </summary>
        /// <param name="lstAUDCurrencyExchangeRates"></param>
        /// <param name="currentProjectLocation"></param>
        /// <returns></returns>
        private static void ExportResultIntoCSV(LinkedList lstAUDCurrencyExchangeRates)
        {
            try
            {
                //Getting Current exe file location
                String currentProjectLocation = GetCurrentFolderName();
                //Removing the bin path and adding csv file name 
                //CSV File Name contains date and time
                currentProjectLocation += "\\Report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + ".csv";
                using (var writer = new StreamWriter(currentProjectLocation))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    var headNode = lstAUDCurrencyExchangeRates.Head;
                    csv.WriteHeader<AUDCurrencyExchange>();
                    csv.NextRecord();
                    while (headNode != null)
                    {
                        AUDCurrencyExchange audCurrencyExchange = new AUDCurrencyExchange()
                        { CountryCode = headNode.CountryCode, CurrencyExchangeValue = headNode.CurrencyExchangeValue };

                        csv.WriteRecord<AUDCurrencyExchange>(audCurrencyExchange);
                        csv.NextRecord();
                        headNode = headNode.Next;
                    }
                }
                Console.WriteLine(@"File Exported to CSV File Sucessfully at Location " + currentProjectLocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while writing into csv. Exception Message: " + ex.Message);
            }
        }

        /// <summary>
        /// Getting Current Project Location
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentFolderName()
        {
            try
            {
                String currentProjectLocation = Directory.GetCurrentDirectory();
                return currentProjectLocation.Substring(0, currentProjectLocation.IndexOf("bin"));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
