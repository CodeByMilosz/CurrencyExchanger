using Newtonsoft.Json;

namespace CurrencyExchanger;

public class CurrencyRateProvider : ICurrencyRateProvider
{
    private readonly HttpClient _httpClient;
    private readonly string _url;

    public CurrencyRateProvider(string url)
    {
        _url = url;
        _httpClient = new HttpClient();
    }

    public async Task<List<Rate>> GetCurrencyRates()
    {
        try
        {
            var httpResponseMessage = await _httpClient.GetAsync(_url);
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var currencies = JsonConvert.DeserializeObject<Root[]>(jsonResponse);
            Rate rate = new Rate
            {
                Code = "PLN",
                Bid = 1.0,
                Ask = 1.0,
            };
            List<Rate> listOfCurrencies = currencies.SelectMany(root =>
                root.Rates).ToList();
            listOfCurrencies.Add(rate);
            return listOfCurrencies;


        }
        catch (Exception e)
        {
            throw new Exception("Invalid API connection", e);
        }
    }
}