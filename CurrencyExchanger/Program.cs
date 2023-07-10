using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchanger
{
    public class Program
    {
        public static async Task Main()
        {
            string url = "http://api.nbp.pl/api/exchangerates/tables/c/?format=json";

            ICurrencyRateProvider rateProvider = new CurrencyRateProvider(url);
            ICurrencyExchangeService exchangeService = new CurrencyExchangeService(rateProvider);

            Console.WriteLine("Enter a balance:");
            if (!double.TryParse(Console.ReadLine(), out double balance))
            {
                throw new Exception("Invalid balance.");
            }

            Console.Write("Enter source currency symbol: ");
            string source = Console.ReadLine().ToUpper();

            Console.Write("Enter target currency symbol: ");
            string target = Console.ReadLine().ToUpper();

            decimal result = await exchangeService.ExchangeCurrency(balance, source, target);
            Console.WriteLine("result: " + result);
        }
    }
}