namespace CurrencyExchanger;

public interface ICurrencyExchangeService
{
    Task<decimal> ExchangeCurrency(double balance, string sourceCurrency, string targetCurrency);
}