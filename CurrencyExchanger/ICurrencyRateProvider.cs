namespace CurrencyExchanger;

public interface ICurrencyRateProvider
{
    Task<List<Rate>> GetCurrencyRates();
}