using Newtonsoft.Json;

namespace CurrencyExchanger;

public class Root
{
    [JsonProperty("rates")]
    public List<Rate> Rates { get; set; }
}