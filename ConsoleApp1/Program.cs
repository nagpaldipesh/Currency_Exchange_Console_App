using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.Interfaces;
using Serilog;
using Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static ICurrencyExchange _currencyExchange;

        private static ILogger<Program> _logger;
        
        static async Task Main(string[] args)
        {
            try
            {
                //Configue Service
                ConfigureService();
                //Get Data From API , Apply Merge Sort and Export into csv Functionality
                await _currencyExchange.ProcessCurrencyExchangeData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught. Exception Message:- " + ex.Message);
                //Logging the error into File
                _logger.LogError("Exception Caught. Exception Message:- " + ex.Message);
            }
        }

        #region Private Methods
        /// <summary>
        /// Configuring Services
        /// </summary>
        private static void ConfigureService()
        {
            //Creating ServiceCollection for Dependency Injection
            var services = new ServiceCollection();
            services.AddScoped<ICurrencyExchangeService, CurrencyExchangeService>();
            services.AddScoped<ICurrencyExchangeManager, CurrencyExchangeManager>();
            services.AddScoped<ICurrencyExchange, CurrencyExchange>();
            //Getting Current exe file location
            String currentProjectLocation = GetCurrentFolderName();
            //Removing the bin path and adding logging into file 
            currentProjectLocation += "\\Logging_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + ".txt";
            //Adding Logging to text file
            var serilogLogger = new LoggerConfiguration()
            .WriteTo.File(currentProjectLocation)
            .CreateLogger();

            services.AddLogging(service =>
            {
                service.SetMinimumLevel(LogLevel.Information);
                service.AddSerilog(logger: serilogLogger, dispose: true);
            });
            var serviceProvider = services.BuildServiceProvider();
            //Getting Manager Service
            _currencyExchange = serviceProvider.GetService<ICurrencyExchange>();
            //Getting Logger
            _logger = serviceProvider.GetService<ILogger<Program>>();
        }

        /// <summary>
        /// Getting Current Project Location
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentFolderName()
        {
            String currentProjectLocation = Directory.GetCurrentDirectory();
            return currentProjectLocation.Substring(0, currentProjectLocation.IndexOf("bin"));
        }

        #endregion
    }
}
