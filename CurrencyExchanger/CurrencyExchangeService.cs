namespace CurrencyExchanger;

public class CurrencyExchangeService : ICurrencyExchangeService
{
    private readonly ICurrencyRateProvider _rateProvider;

    public CurrencyExchangeService(ICurrencyRateProvider rateProvider)
    {
        _rateProvider = rateProvider;
    }

    public async Task<decimal> ExchangeCurrency(double balance, string sourceCurrency, string targetCurrency)
    {
        List<Rate> rates = await _rateProvider.GetCurrencyRates();

        if (!IsCorrectCurrency(sourceCurrency, rates) || !IsCorrectCurrency(targetCurrency, rates))
        {
            throw new Exception("Invalid currency code");
        }

        Rate sourceRate = rates.Single(r => r.Code == sourceCurrency);
        Rate targetRate = rates.Single(r => r.Code == targetCurrency);

        decimal result = (decimal)(balance * (sourceRate.Ask / targetRate.Bid));
        return Math.Round(result,2,MidpointRounding.AwayFromZero);
    }

    private bool IsCorrectCurrency(string code, List<Rate> rates)
    {
        return rates.Any(element => element.Code == code);
    }
}